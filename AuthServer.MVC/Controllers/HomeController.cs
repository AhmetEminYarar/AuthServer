using AuthServer.Data.Entity;
using AuthServer.DTO.Request.Users;
using AuthServer.DTO.Response.Users;
using AuthServer.MVC.Models;
using AutoMapper;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthServer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<UserGetResponse>>(await _userService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] UserAddRequest request)
        {
            var User = _mapper.Map<User>(request);
            await _userService.Add(User, request.userImageURL);          
            return RedirectToAction("Index");
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
