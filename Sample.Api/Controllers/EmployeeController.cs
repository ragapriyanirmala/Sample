using Microsoft.AspNetCore.Mvc;
using Sample.Api.CustomActionFilters;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeServices.Get();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var employee = _employeeServices.GetById(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeDTO request)
        {
            if (ModelState.IsValid)
            {
                var response = await _employeeServices.Create(request);
                if (response == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public IActionResult Update([FromRoute] Guid id, AddEmployeeDTO request)
        {
            var employee = _employeeServices.Update(id, request);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var employee = _employeeServices.Delete(id);
            if (employee == false)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
