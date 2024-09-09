using MeuSiteMVC.Helper;
using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeuSiteMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;

        public LoginController(IUserRepository userRepository, ISessao sessao)
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //se o user estiver logado, ja sera direcionado para a home

            if(_sessao.GetSessionUser() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Exit()
        {
            _sessao.RemoveSessionUser();

            return RedirectToAction("Index", "Login");
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
                                _sessao.CreateSessionUser(user);
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
