using AuthServer.Data.Entity;
using AuthServer.Data.Migrations;
using AuthServer.Data.UnitOfWork;
using AuthServer.DTO.Request.People;
using AuthServer.DTO.Response.People;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : Controller
    {
        private readonly IPersonService _person;
        private readonly IUnitOfWork _unit;

        public PersonController(IPersonService person, IUnitOfWork unit)
        {
            _person = person;
            _unit = unit;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new PersonGetAllResponse().Map(await _person.GetAll()));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PersonAddRequest request)
        {
            Person person = request.Map(request);
            try
            {
                var response = await _person.Add(person, request.personImageURL);
                await _unit.CommitTranssections();
                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{personId}")]
        public async Task<IActionResult> GetById(int personId)
        {
            var response = await _person.GetById(personId);

            return Ok(new PersonGetByIdResponse().Map(response));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] PersonUpdateRequest request)
        {

            Person person = request.Map(request);

            try
            {
                var response = await _person.Update(person, request.personImageURL);
                await _unit.CommitTranssections();

                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            try
            {
                var response = await _person.GetById(personId);

                await _person.Delete(response);
                await _unit.CommitTranssections();

                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();

                return BadRequest(ex.Message);
            }


        }
    }
}
