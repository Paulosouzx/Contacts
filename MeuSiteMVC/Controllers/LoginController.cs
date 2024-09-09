using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeuSiteMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {

            try{

                if (ModelState.IsValid)
                {

                   UserModel user = _userRepository.SearchLogin(loginModel.Login);

                       if(user != null)
                       {

                            if (user.ValidPass(loginModel.Password))
                            {
                                return RedirectToAction("Index", "Home");
                            }


                        TempData["messageError"] = $"Opss... Password is invalid. Try again, please";
                       }

                    TempData["messageError"] = $"Opss... Password or Login invalid. Try again, please";

                }

                return View("Index");
            }
            catch (Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to login , Error details: {e.Message}";
                return View("Index");
            }
        }
    }
}
