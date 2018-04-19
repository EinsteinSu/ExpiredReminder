using System.Collections.Generic;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.Business
{
    public class ExpiredCases
    {
        public ExpiredPolicy Policy { get; set; }

        public IList<Case> Cases { get; set; }
    }
}