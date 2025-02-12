using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;
using System.Text.Json;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _branchServices;
        private readonly ILogger<BranchController> _logger;
        public BranchController(IBranchServices branchServices,ILogger<BranchController> logger)
        {
            _branchServices = branchServices;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles ="Reader")]
        public async Task<IActionResult> Get([FromQuery] string? filteron, [FromQuery] string? filterquery,
            [FromQuery] string? sortby, [FromQuery] bool? isascending = true)
        {
            //_logger.LogInformation("Get Branches is invoked");
            //_logger.LogWarning("Warning");
            //_logger.LogError("Error");
            //throw new Exception("This is a test exception");
            var branches = await _branchServices.Get(filteron, filterquery, sortby, isascending ?? true);
            //_logger.LogInformation($"Finished with data : {JsonSerializer.Serialize(branches)}");
            return Ok(branches);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var branch = await _branchServices.GetById(id);
            return Ok(branch);
        }
        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddBranchDTO request)
        {
            var response = await _branchServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddBranchDTO request)
        {
            var response = await _branchServices.Update(id, request);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _branchServices.Delete(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
