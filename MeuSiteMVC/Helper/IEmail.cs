namespace MeuSiteMVC.Helper
{
    public interface IEmail
    {
        bool Send(string email, string subject, string message);
    }
}
