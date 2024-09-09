using MeuSiteMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteMVC.Models
{
    public class UserWithoutPassModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter User's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter User's Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter User's Email")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter User's Perfil")]
        public PerfilEnum? Perfil { get; set; }




    }
}
