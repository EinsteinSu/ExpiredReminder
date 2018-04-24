using System;
using System.Collections.Generic;
using System.Linq;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.Business
{
    public class CaseReminder
    {
        private readonly IList<Case> _cases;
        private readonly int _minDay;
        private readonly int _maxDay;
        private readonly DateTime _endDate;

        public CaseReminder(IList<Case> cases, int minDay, int maxDay, DateTime endDate)
        {
            _cases = cases;
            _minDay = minDay;
            _maxDay = maxDay;
            _endDate = endDate;
        }

        public IList<Case> RemindCases
        {
            get
            {
                return _cases.Where(c => CanRemind(c, _minDay, _maxDay, _endDate)).ToList();
            }
        }

        private bool CanRemind(Case c, int minDay, int maxDay, DateTime endDate)
        {
            return c.FirstTime.DateDiff(endDate) >= minDay && c.FirstTime.DateDiff(endDate) < maxDay && !c.CancelRemind;
        }
    }
}