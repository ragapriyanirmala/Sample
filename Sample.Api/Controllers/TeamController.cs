using Microsoft.AspNetCore.Mvc;
using Sample.Datahub.Models.Domain;
using Sample.Services.BusinessLogic;
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
    }
}
