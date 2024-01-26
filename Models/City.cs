using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
