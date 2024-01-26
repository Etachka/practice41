using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace practice.Models
{
    public class Organizers
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Mail { get; set; }
        public DateOnly? Birthday { get; set; }

        [Required]
        public int? CountryID { get; set; }
        public Country Country { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(1000)]
        public string? Photo { get; set; }
        public char? Gender { get; set; }

        [Required]
        public int IdNumber { get; set; }
    }
}
