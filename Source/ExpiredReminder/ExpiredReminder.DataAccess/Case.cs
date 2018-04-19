using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpiredReminder.DataAccess
{
    public class Case
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Accuser { get; set; }

        [MaxLength(20)]
        public string Accused { get; set; }

        [ForeignKey("Lawyer")]
        public int LawyerId { get; set; }

        public virtual Lawyer Lawyer { get; set; }

        public string Cause { get; set; }


    }

    public class Lawyer
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}
