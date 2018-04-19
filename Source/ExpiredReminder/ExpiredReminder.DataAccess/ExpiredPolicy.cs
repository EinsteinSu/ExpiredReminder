using System.ComponentModel.DataAnnotations;

namespace ExpiredReminder.DataAccess
{
    public class ExpiredPolicy
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public int MinDay { get; set; }

        public int MaxDay { get; set; }

    }
}