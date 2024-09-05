using MeuSiteMVC.Models;
using System.Collections.Generic;

namespace MeuSiteMVC.Repository
{
    public interface IContactRepository
    {
        ContactModel IdList(int id);
        List<ContactModel> GetAllPeople(); 
        ContactModel Adc(ContactModel contact);
        ContactModel Refresh(ContactModel contact);
        bool Delete(int id);

    }
}
