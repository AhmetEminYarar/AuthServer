using AuthServer.Data.Entity;
using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Request.Users;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddAsync([FromBody] UserAddRequest request)
        {
            User users = request.Map(request);
            try
            {
                var response = await _userService.Add(users);
                await _unitOfWork.CommitTranssections();
                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTranssections();
                return BadRequest(ex.Message);
            }
        }
    }
}

