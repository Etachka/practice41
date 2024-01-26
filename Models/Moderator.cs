using System;
using System.ComponentModel.DataAnnotations;

namespace practice.Models
{
    public class Moderator
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FIO { get; set; }
        public char? Gender { get; set; }

        [StringLength(100)]
        public string? Mail { get; set; }
        public DateOnly? Birthday{ get; set; }

        [Required]
        public int CountryID { get; set; }
        public Country Country { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(1000)]
        public string Photo { get; set; }
    }
}
