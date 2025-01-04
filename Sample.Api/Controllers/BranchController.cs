using Microsoft.AspNetCore.Http.HttpResults;
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
        public IActionResult Get()
        {
            var branches = _branchServices.Get();
            return Ok(branches);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var branch = _branchServices.GetById(id);
            return Ok(branch);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddBranchDTO request)
        {
            var response = _branchServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
    }
}
