using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class ContactModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Contact's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Contact's Email")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        // Backing field for the Email property
        private string _email;

        [Required(ErrorMessage = "Enter Contact's Phone")]
        [Phone(ErrorMessage = "Phone invalid")]
        public string Phone { get; set; }
        public int? UserID { get; set; }
        public UserModel User { get; set; }

    }
}
