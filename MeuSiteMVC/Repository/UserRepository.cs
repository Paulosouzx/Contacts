using MeuSiteMVC.Data;
using MeuSiteMVC.Models;
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

        public UserModel IdList(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.ID == id);
        }

        public List<UserModel> GetAllPeople()
        {
             return _bancoContext.Users.ToList();
        }

        public UserModel Adc(UserModel user)
        {
            //Gravar no banco de dados
            user.DataRegistration = DateTime.Now;
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
    }
}
