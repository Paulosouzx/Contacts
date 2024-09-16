using MeuSiteMVC.Models;
using System.Collections.Generic;

namespace MeuSiteMVC.Repository
{
    public interface IUserRepository
    {
        UserModel SearchLogin(string login);
        UserModel SearchEmailAndLogin(string email, string login);
        UserModel IdList(int id);
        List<UserModel> GetAllPeople(); 
        UserModel Adc(UserModel user);
        UserModel Refresh(UserModel user);
        bool Delete(int id);
        UserModel ChangePassword(ChangePasswordModel changePassword);

    }
}
