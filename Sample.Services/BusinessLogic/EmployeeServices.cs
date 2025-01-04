using Sample.Datahub.Models.Domain;
using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Services.BusinessLogic
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeData _data;
        private readonly IBranchData _branchData;
        public EmployeeServices(IEmployeeData data, IBranchData branchdata)
        {
            _data = data;
            _branchData = branchdata;
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
        public EmpolyeeDTO Create(AddEmployeeDTO input)
        {
            var branchid = _branchData.GetBranchIdByCode(input.BranchCode);
            if (branchid != null)
            {
                var employee = new Employee()
                {
                    Name = input.Name,
                    Address = input.Address,
                    EmployeeImageUrl = input.EmployeeImageUrl,
                    BranchId = branchid.Value,
                    TeamId = new Guid()
                };
                employee = _data.Create(employee);
                var output = new EmpolyeeDTO()
                {
                    Name = employee.Name,
                    Address = employee.Address,
                    EmployeeImageUrl = employee.EmployeeImageUrl
                };
                return output;
            }
            return null;
           
        }
    }
    
}
