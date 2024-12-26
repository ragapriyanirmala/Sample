using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Services.BusinessLogic
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeData _data;
        public EmployeeServices(IEmployeeData data)
        {
            _data = data;
        }
        public List<EmpolyeeDTO> Get()
        {
            var employeedata = _data.Get();
            var employees = new List<EmpolyeeDTO>();
            foreach (var employee in employeedata)
            {
                employees.Add(new EmpolyeeDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    EmployeeImageUrl = employee.EmployeeImageUrl

                });
            }
            return employees;
        }
        public EmpolyeeDTO GetById(Guid id)
        {
            var employeedata = _data.GetById(id);
            var employee = new EmpolyeeDTO()
            {
                Id = employeedata.Id,
                Name = employeedata.Name,
                Address = employeedata.Address,
                EmployeeImageUrl = employeedata.EmployeeImageUrl
            };
            return employee;
        }
    }
}
