using System.ComponentModel.DataAnnotations;

namespace ip2DonemOdev.DAL.Entities
{
    public class User
    {
        public int Id { get; set; } // sütun adı
        [Required]
        public string Email { get; set; } // sütun adı
        [Required]
        public string PasswordHash { get; set; } // sütun adı
        public bool IsAdmin { get; set; } // sütun adı
    }
}
