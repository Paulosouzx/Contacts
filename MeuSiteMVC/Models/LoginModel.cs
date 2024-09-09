using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
}
