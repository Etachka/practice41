using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Jury
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FIO { get; set; }

        [Required]
        [StringLength(100)]
        public string Mail { get; set; }
        public char? gender { get; set; }
        public DateOnly? Birthday { get; set; }

        [Required]
        public int? Country { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
        public int? DirectionId { get; set; }
        public Direction Direction { get; set; }

        [StringLength(100)]
        public string? Action { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        [StringLength(1000)]
        public string? Photo { get; set; }
        public int? IdNumber { get; set; }
    }
}
