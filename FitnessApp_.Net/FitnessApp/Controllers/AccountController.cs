using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
