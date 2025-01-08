using Microsoft.AspNetCore.Mvc;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _branchServices;
        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var branches = await _branchServices.Get();
            return Ok(branches);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var branch = await _branchServices.GetById(id);
            return Ok(branch);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBranchDTO request)
        {
            var response = await _branchServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        [HttpPut]
        [Route("{id:Guid}")]
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
