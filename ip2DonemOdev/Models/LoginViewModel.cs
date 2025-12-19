using System.ComponentModel.DataAnnotations;

namespace ip2DonemOdev.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalı.")]
        public string Password { get; set; }
    }
}
