using MeuSiteMVC.Models;

namespace MeuSiteMVC.Helper
{
    public interface ISession
    {
        void CreateSessionUser(UserModel user);
        void RemoveSessionUser();
        UserModel GetSessionUser();
    }
}
