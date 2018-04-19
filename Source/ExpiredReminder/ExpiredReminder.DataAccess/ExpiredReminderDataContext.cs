using System.Data.Entity;

namespace ExpiredReminder.DataAccess
{
    public class ExpiredReminderDataContext : DbContext
    {
        public ExpiredReminderDataContext() : base("name=Reminder")
        {
        }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Lawyer> Lawyers { get; set; }

        public DbSet<ExpiredPolicy> ExpiredPolicies { get; set; }
    }
}