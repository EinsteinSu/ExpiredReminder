using ExpiredReminder.DataAccess;

namespace ExpiredReminder.Common
{
    public class ReminderContext : ExpiredReminderDataContext
    {
        public ReminderContext() : base("name=Reminder")
        {
        }
    }
}