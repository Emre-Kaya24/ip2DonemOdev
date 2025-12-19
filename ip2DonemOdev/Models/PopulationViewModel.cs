using System.ComponentModel.DataAnnotations;

namespace ip2DonemOdev.Models
{
    public class PopulationViewModel
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public long Population { get; set; }
    }
}
