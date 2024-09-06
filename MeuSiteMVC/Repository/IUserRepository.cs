using MeuSiteMVC.Models;
using System.Collections.Generic;

namespace MeuSiteMVC.Repository
{
    public interface IUserRepository
    {
        UserModel IdList(int id);
        List<UserModel> GetAllPeople(); 
        UserModel Adc(UserModel user);
        UserModel Refresh(UserModel user);
        bool Delete(int id);

    }
}
