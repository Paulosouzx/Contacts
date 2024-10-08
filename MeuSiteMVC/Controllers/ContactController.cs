﻿using MeuSiteMVC.Filters;
using MeuSiteMVC.Helper;
using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeuSiteMVC.Controllers
{

    [PageForLogedUser]
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;
        private readonly ISessao _sessao;

        public ContactController(IContactRepository contactRepository, ISessao sessao)
        {
            _contactRepository = contactRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UserModel userLogin = _sessao.GetSessionUser();
            List<ContactModel> contacts = _contactRepository.GetAll(userLogin.ID);
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
            try
            {
               bool deleted = _contactRepository.Delete(id);

                if (deleted) 
                {
                    TempData["messageSuccess"] = "User Deleted successfully";
                }
                else
                {
                    TempData["messageError"] = $"Ops, Failed to Delete the contact";
                }

                    return RedirectToAction("Index");
            }

            catch (System.Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to Delete the user, Error details: {e.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogin = _sessao.GetSessionUser();
                    contact.UserID = userLogin.ID;
                    _contactRepository.Adc(contact);
                    TempData["messageSuccess"] = "User added successfully";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to add user, Error details: {e.Message}";
                return RedirectToAction("Index");   

            }

        }

        [HttpPost]
        public IActionResult Editar(ContactModel contact)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogin = _sessao.GetSessionUser();
                    contact.UserID = userLogin.ID;
                    _contactRepository.Refresh(contact);
                    TempData["messageSuccess"] = "User Altered successfully";
                    return RedirectToAction("Index");
                }

                //Como o nome da view é o msm que da acao, entao nao forcamos uma entrada em outra view tipo("<View>", contact); 
                return View();
            }
            catch (System.Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to Alter user, Error details: {e.Message}";
                return RedirectToAction("Index");

            }
        }

        
    }
}
