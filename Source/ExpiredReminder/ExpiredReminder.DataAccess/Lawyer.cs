using System.ComponentModel.DataAnnotations;

namespace ExpiredReminder.DataAccess
{
    public class Lawyer
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}