using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Response.People;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IUnitOfWork _unitOfWork;
        public PersonController(IPersonService personService, IUnitOfWork unitOfWork)
        {
            _personService = personService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
           return View(new PersonGetAllResponse().Map(await _personService.GetAll()).ToList());
        }
    }
}
