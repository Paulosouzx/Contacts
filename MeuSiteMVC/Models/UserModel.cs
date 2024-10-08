﻿using MeuSiteMVC.Enums;
using MeuSiteMVC.Helper;
using System;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "Enter User's Perfil")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Enter User's Password")]
        public string Password { get; set; }
        public DateTime DataRegistration { get; set; }
        public DateTime DataUpdate { get; set; }

        public bool ValidPass(string password)
        {
            return Password == password.HashGenerator();
        }
            
        public void SetPassHash()
        {
            Password = Password.HashGenerator();
        }

        public void SetNewPassword(string newPass)
        {
            Password = newPass.HashGenerator();
        }

        public string GenerateNewPassword()
        {
            string newPass = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPass.HashGenerator();
            return newPass;
        }

        public virtual List<ContactModel> Contacts { get; set; }


    }
}
