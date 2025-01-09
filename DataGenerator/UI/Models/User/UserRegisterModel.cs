using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UserRegisterModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Name and Surname Cannot be Null")]
        public string NameSurname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Username Adı Cannot be Null")]
        public string Username { get; set; }


        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Mail Cannot be Null")]
        public string Email { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Password Cannot be Null")]
        public string Password { get; set; }


        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Passwords Doesn't Match")]
        public string ConfirmPassword { get; set; }
    }
}
