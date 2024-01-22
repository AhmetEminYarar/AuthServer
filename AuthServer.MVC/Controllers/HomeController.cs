using AuthServer.Data.Entity;
using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Request.People;
using AuthServer.DTO.Response.People;
using AuthServer.MVC.Models;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthServer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _person;
        private readonly IUnitOfWork _unit;

        public HomeController(IPersonService person, IUnitOfWork unit)
        {
            _person = person;
            _unit = unit;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new PersonGetAllResponse().Map(await _person.GetAll()));
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] PersonAddRequest request)
        {
            Person person = request.Map(request);
            try
            {
                var response = await _person.Add(person, request.personImageURL);
                await _unit.CommitTranssections();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                await _unit.RollbackTranssections();
                return View(Error());
            }

        }
        public IActionResult ShowImage(string fileName)
        {
            var filePath = Path.Combine("wwwroot", "Image", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, "image/jpeg");
            }
            else
            {
                return File("wwwroot/default-image.jpg", "image/jpeg");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
