using MeuSiteMVC.Models;
using System.Collections.Generic;

namespace MeuSiteMVC.Repository
{
    public interface IContactRepository
    {
        Contact IdList(int id);
        List<Contact> GetAll(); 
        Contact Adicionar(Contact contact);
        Contact Refresh(Contact contact);

    }
}
