using System;
using System.Collections.Generic;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.Business
{
    public class CaseReminderCollection : IDisposable
    {
        private readonly IList<Case> _cases;
        private readonly DateTime _endDate;
        private readonly ExpiredReminderDataContext _context = new ExpiredReminderDataContext();
        public CaseReminderCollection(IList<Case> cases, DateTime endDate)
        {
            _cases = cases;
            _endDate = endDate;
            ExpiredCaseses = new List<ExpiredCases>();
        }

        public void Calculate()
        {
            foreach (var policy in _context.ExpiredPolicies)
            {
                CaseReminder reminder = new CaseReminder(_cases, policy.MinDay, policy.MaxDay, _endDate);
                ExpiredCaseses.Add(new ExpiredCases { Cases = reminder.RemindCases, Policy = policy });
            }
        }

        public IList<ExpiredCases> ExpiredCaseses { get; }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}