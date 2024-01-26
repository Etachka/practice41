using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice.Models
{
    public class Country
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryEngName { get; set; }

        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        [Required]
        public int CodeNumber { get; set; }
    }
}
