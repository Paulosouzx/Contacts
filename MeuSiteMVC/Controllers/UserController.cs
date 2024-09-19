using MeuSiteMVC.Filters;
using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeuSiteMVC.Controllers
{

    [RetrictPageAdm]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;

        public UserController(IUserRepository userRepository, IContactRepository contactRepository)
        {
            _userRepository = userRepository;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> user = _userRepository.GetAllPeople();

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DeleteConfirm(int id)
        {

            UserModel user = _userRepository.IdList(id);
            return View(user);
        }

        public IActionResult Editar(int id)
        {
            UserModel user = _userRepository.IdList(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _userRepository.Adc(user);
                    TempData["messageSuccess"] = "User added successfully";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (System.Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to add user, Error details: {e.Message}";
                return RedirectToAction("Index");

            }

        }

            public IActionResult Delete(int id)
            {
                try
                {
                    bool deleted = _userRepository.Delete(id);

                    if (deleted)
                    {
                        TempData["messageSuccess"] = "Contact Deleted successfully";
                    }
                    else
                    {
                        TempData["messageError"] = $"Ops, Failed to Delete the contact";
                    }

                    return RedirectToAction("Index");
                }

                catch (System.Exception e)
                {
                    TempData["messageError"] = $"Ops, Failed to Delete the contact, Error details: {e.Message}";
                    return RedirectToAction("Index");

                }
            }

        public IActionResult ContactListPerUserID(int id)
        {
            List<ContactModel> contact = _contactRepository.GetAll(id);
            return PartialView("_ContactUser", contact);
        }


        [HttpPost]
        public IActionResult Editar(UserWithoutPassModel userWithoutPass)
        {

            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel() {
                        ID = userWithoutPass.ID,
                        Name = userWithoutPass.Name,
                        Login = userWithoutPass.Login,
                        Email = userWithoutPass.Email,
                        Perfil = userWithoutPass.Perfil
                    };
                    

                    _userRepository.Refresh(user);
                    TempData["messageSuccess"] = "Contact Altered successfully";
                    return RedirectToAction("Index");
                }

                //Como o nome da view é o msm que da acao, entao nao forcamos uma entrada em outra view tipo("<View>", contact); 
                return View();
            }
            catch (System.Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to Alter contact, Error details: {e.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
