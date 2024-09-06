using MeuSiteMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter User's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter User's Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter User's Email")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Enter User's Login")]
        public string Password { get; set; }
        public DateTime DataRegistration { get; set; }
        public DateTime DataUpdate { get; set; }

        public UserModel() { }


    }
}
