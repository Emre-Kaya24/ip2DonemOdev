using System.ComponentModel.DataAnnotations;

namespace ip2DonemOdev.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-posta boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı.")]
        public string Password { get; set; }
    }
}
