using MeuSiteMVC.Models;

namespace MeuSiteMVC.Helper
{
    public interface ISessao
    {
        void CreateSessionUser(UserModel user);
        void RemoveSessionUser();
        UserModel GetSessionUser();
    }
}
