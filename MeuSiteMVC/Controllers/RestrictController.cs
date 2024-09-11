using MeuSiteMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteMVC.Controllers
{
    [PageForLogedUser]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
