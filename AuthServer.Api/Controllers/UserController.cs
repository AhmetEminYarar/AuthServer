using AuthServer.Data.Entity;
using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Request.Users;
using AuthServer.DTO.Response.Users;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AddAsync([FromForm] UserAddRequest request)
        {
            var User = _mapper.Map<User>(request);
            var NewUser = await _userService.Add(User,request.userImageURL);
            return Created(string.Empty, NewUser);
        }

        [HttpGet(Name = "GetUserAll"), /*Authorize(Roles = "Admin")*/]
        public async Task<IActionResult> GetAllAsync()
        {
            var NewUser = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserGetResponse>>(NewUser));
        }

        [HttpPut,/* Authorize(Roles = "Owner")*/]
        public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateRequest request)
        {
            var User = _mapper.Map<User>(request);
            var NewUser = await _userService.Update(User,request.userImageURL);
            return Ok(NewUser);
        }

        [HttpGet("{TCKN}"), /*Authorize(Roles = "Owner")*/]
        public async Task<IActionResult> GetByTCKN(string TCKN)
        {
            var NewUser = await _userService.GetByTCKN(TCKN);
            return Ok(_mapper.Map<UserGetByTCKNResponse>(NewUser));
        }
    }
}

