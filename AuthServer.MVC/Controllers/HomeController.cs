using AuthServer.Data.Entity;
using AuthServer.MVC.ApiServices;
using AuthServer.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AuthServer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonServices _person;

        public HomeController(PersonServices person)
        {
            _person = person;
        }

        public async Task<IActionResult> Index()
        {
            var ApiData = await _person.GetApi();
            var ApiList = JsonConvert.DeserializeObject<List<Person>>(ApiData);
            return View(ApiList);
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
