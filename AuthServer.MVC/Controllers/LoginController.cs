using AuthServer.DTO.Request.Authentication;
using AutoMapper;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Newtonsoft.Json;

namespace AuthServer.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IMapper _mapper;

        public LoginController(IAuthorizeService authorizeService, IMapper mapper)
        {
            _authorizeService = authorizeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            string response = await _authorizeService.UserValidator(request);
            Response.Cookies.Append("JWT", response);
            return RedirectToAction("Index", "Home");
        }
    }
}
