using MeuSiteMVC.Models;
using System.Collections.Generic;

namespace MeuSiteMVC.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll(int userID);
        ContactModel IdList(int id);
        ContactModel Adc(ContactModel contact);
        ContactModel Refresh(ContactModel contact);
        bool Delete(int id);

    }
}
