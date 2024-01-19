using AuthServer.Data.Entity;
using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Response.People;
using AuthServer.MVC.Models;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthServer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IPersonService personService,IUnitOfWork unitOfWork)
        {
            _personService = personService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {      
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
