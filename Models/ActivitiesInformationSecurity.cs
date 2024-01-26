using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class ActivitiesInformationSecurity
    {
        [Required]
        public int Id { get; set; }

        [StringLength(500)]
        public string? Ivent { get; set; }
        public DateOnly? Data { get; set; }
        public int? Days { get; set; }

        [Required]
        public int City { get; set; }
    }
}
