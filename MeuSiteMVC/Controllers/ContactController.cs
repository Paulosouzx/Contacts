using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeuSiteMVC.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAllPeople();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Editar(int id)
        {
            ContactModel contact = _contactRepository.IdList(id);
            return View(contact);
        }

        public IActionResult DeleteConfirm(int id)
        {

            ContactModel contact = _contactRepository.IdList(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {

                _contactRepository.Adc(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Editar(ContactModel contact)
        {

            if (ModelState.IsValid)
            {
                _contactRepository.Refresh(contact);
                return RedirectToAction("Index");
            }

            //Como o nome da view é o msm que da acao, entao nao forcamos uma entrada em outra view tipo("<View>", contact); 
            return View();
        }

        
    }
}
