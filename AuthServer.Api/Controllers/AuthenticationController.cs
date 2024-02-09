using AuthServer.DTO.Request.Authentication;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthorizeService _authenticationService;

        public AuthenticationController(IAuthorizeService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken([FromForm] AuthenticationRequest request)
        {
            var response = await _authenticationService.UserValidator(request);
            return Ok(response);
        }
    }
}

