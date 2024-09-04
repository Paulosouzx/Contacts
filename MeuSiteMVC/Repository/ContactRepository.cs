using MeuSiteMVC.Data;
using MeuSiteMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeuSiteMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BancoContext _bancoContext;

        public ContactRepository(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public Contact IdList(int id)
        {
            return _bancoContext.Contacts.FirstOrDefault(x => x.ID == id);
        }
        public List<Contact> GetAll()
        {
            return _bancoContext.Contacts.ToList();
        }

        public Contact Adicionar(Contact contact)
        {
            //Gravar no banco de dados
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();
            return contact;
        }

        public Contact Delete(Contact contact)
        {
            _bancoContext.Contacts.Remove(contact);
            _bancoContext.SaveChanges();
            return contact;
        }

        public Contact Refresh(Contact contact)
        {
            Contact contactDB = IdList(contact.ID);

            if (contactDB == null)
            {
                throw new System.Exception("Refresh error");
            }

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _bancoContext.Contacts.Update(contactDB);
            _bancoContext.SaveChanges();
            return contact;
        }
    }
}
