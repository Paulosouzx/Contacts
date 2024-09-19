using MeuSiteMVC.Data;
using MeuSiteMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuSiteMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BancoContext _bancoContext;

        public UserRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UserModel SearchLogin(string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }
        public UserModel SearchEmailAndLogin(string email, string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());

        }

        public UserModel IdList(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.ID == id);
        }

        public List<UserModel> GetAllPeople()
        {
            return _bancoContext.Users
                .Include(x => x.Contacts)
                .ToList();
        }

        public UserModel Adc(UserModel user)
        {
            //Gravar no banco de dados
            user.DataRegistration = DateTime.Now;
            user.SetPassHash();
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UserModel Refresh(UserModel user)
        {

            var userDB = IdList(user.ID) ?? throw new Exception("Contact not found");
            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.DataUpdate = DateTime.Now;
            userDB.Perfil = user.Perfil;

            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();
            return userDB;
        }

        public bool Delete(int id)
        {
            var userDB = IdList(id) ?? throw new Exception("Contact not can be deleted");
            _bancoContext.Users.Remove(userDB);
            _bancoContext.SaveChanges();
            return true;
        }


        public UserModel ChangePassword(ChangePasswordModel changePassword)
        {
            UserModel userDB = IdList(changePassword.ID);

            if (userDB == null) throw new Exception("Error in change the password, user not found.");

            if (!userDB.ValidPass(changePassword.CurrentPass)) throw new Exception("Current password does not match");

            if (userDB.ValidPass(changePassword.NewPass)) throw new Exception("New password needs to be different from the current password");

            userDB.SetNewPassword(changePassword.NewPass);
            userDB.DataUpdate = DateTime.Now;

            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();

            return userDB;


        }
    }
}