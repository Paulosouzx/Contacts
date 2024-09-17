using MeuSiteMVC.Data;
using MeuSiteMVC.Models;
using System;
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

        public ContactModel IdList(int id)
        {
            return _bancoContext.Contacts.FirstOrDefault(x => x.ID == id);
        }

        public List<ContactModel> GetAll(int userID)
        {
             return _bancoContext.Contacts.Where(x => x.UserID == userID).ToList();
        }

        public ContactModel Adc(ContactModel contact)
        {
            //Gravar no banco de dados
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();
            return contact;
        }

        public ContactModel Refresh(ContactModel contact)
        {

            var contactDB = IdList(contact.ID) ?? throw new Exception("Contact not found");
            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _bancoContext.Contacts.Update(contactDB);
            _bancoContext.SaveChanges();
            return contactDB;
        }

        public bool Delete(int id)
        {
            var contactDB = IdList(id) ?? throw new Exception("Contact not can be deleted");
            _bancoContext.Contacts.Remove(contactDB);
            _bancoContext.SaveChanges();   
            return true;
        }
    }
}
