using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class ChangePasswordModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter the current password")]
        public string CurrentPass { get; set; }

        [Required(ErrorMessage = "Enter the new password")]
        public string NewPass { get; set; }

        [Required(ErrorMessage = "confirm the new password")]
        [Compare("NewPass", ErrorMessage = "The passwords don't match")]
        public string ConfirmPass { get; set; }
    }
}
