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
            List<Contact> contacts = _contactRepository.GetAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            Contact contact = _contactRepository.IdList(id);
            return View(contact);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _contactRepository.Adicionar(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            _contactRepository.Adicionar(contact);
            return RedirectToAction("Index");
        }

    }
}
