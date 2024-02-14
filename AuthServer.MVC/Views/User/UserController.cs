using Microsoft.AspNetCore.Mvc;

namespace AuthServer.MVC.Views.User
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
