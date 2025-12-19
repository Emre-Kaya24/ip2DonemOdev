using System.ComponentModel.DataAnnotations;

namespace ip2DonemOdev.DAL.Entities
{
    public class Slider
    {
        public int Id { get; set; } // sütun adı
        [Required]
        public string Title { get; set; } // sütun adı
        [Required]
        public string Description { get; set; } // sütun adı
        [Required]
        public string Image { get; set; } // sütun adı
    }
}
