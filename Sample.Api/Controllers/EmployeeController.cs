using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create([FromBody] AddEmployeeDTO Request)
        {
            var response = _employeeServices.Create(Request);
            if (response == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
    }
}
