using MeuSiteMVC.Helper;
using MeuSiteMVC.Models;
using MeuSiteMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeuSiteMVC.Controllers
{
    public class ResetPasswordController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;
        public ResetPasswordController(IUserRepository userRepository, ISessao sessao)
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePassword)
        {

            try
            {
                UserModel userLogin = _sessao.GetSessionUser();
                changePassword.ID = userLogin.ID;

                if (ModelState.IsValid)
                {

                    _userRepository.ChangePassword(changePassword);
                    TempData["messageSuccess"] = "Password Altered successfully";
                    return View("Index", changePassword);
                }
                return View("Index", changePassword);
            }
            catch(Exception e)
            {
                TempData["messageError"] = $"Ops, Failed to Alter Password, Error details: {e.Message}";
                return View("Index", changePassword);
            }
        }
    }
}
