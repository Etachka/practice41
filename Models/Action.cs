using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Action
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionName { get; set; }
        public int? DayNumber { get; set; }
        public TimeOnly? TimeBegin { get; set; }
        public int? OrganizerID { get; set; }
        public Organizers Organizers { get; set; }

        [StringLength(100)]
        public string? ModeratorName { get; set; }
        public Moderator Moderator { get; set; }
        public int? IdIvent { get; set; }
        public Ivent Ivent { get; set; }
    }
}
