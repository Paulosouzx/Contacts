using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Enter Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
    }
}
