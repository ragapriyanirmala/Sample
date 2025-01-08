using Microsoft.AspNetCore.Mvc;
using Sample.Datahub.Models.Domain;
using Sample.Services.BusinessLogic;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamServices _teamServices;
        public TeamController(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var teams = _teamServices.Get();
            return Ok(teams);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var team = _teamServices.GetById(id);
            return Ok(team);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddTeamDTO request)
        {
            var response = _teamServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] AddTeamDTO request)
        {
            var team = _teamServices.Update(id, request);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var team = _teamServices.Delete(id);
            if(team==false)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}