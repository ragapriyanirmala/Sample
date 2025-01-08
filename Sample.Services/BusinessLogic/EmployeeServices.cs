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
        private readonly ITeamData _teamData;
        public EmployeeServices(IEmployeeData data, IBranchData branchdata, ITeamData teamData)
        {
            _data = data;
            _branchData = branchdata;
            _teamData = teamData;
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
        public async Task<EmpolyeeDTO> Create(AddEmployeeDTO input)
        {
            var branchid =await _branchData.GetBranchIdByCode(input.BranchCode);
            var teamid =_teamData.GetTeamIdByName(input.TeamName);
            if (branchid != null && teamid != null)
            {
                var employee = new Employee()
                {
                    Name = input.Name,
                    Address = input.Address,
                    EmployeeImageUrl = input.EmployeeImageUrl,
                    BranchId = branchid.Value,
                    TeamId = teamid.Value
                };
                employee = _data.Create(employee);
                var output = new EmpolyeeDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    EmployeeImageUrl = employee.EmployeeImageUrl
                };
                return output;
            }
            return null;
        }
        public EmpolyeeDTO Update(Guid id, AddEmployeeDTO input)
        {
            var branchid = _branchData.GetBranchIdByCode(input.BranchCode);
            var teamid = _teamData.GetTeamIdByName(input.TeamName);
            var employee = _data.GetById(id);
            if (branchid != null && teamid != null && employee != null)
            {
                employee.BranchId= branchid.Result.Value;
                employee.TeamId= teamid.Value;
                employee.Name= input.Name;
                employee.Address= input.Address;
                employee.EmployeeImageUrl= input.EmployeeImageUrl;
                employee= _data.Update(employee);
                var output = new EmpolyeeDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    EmployeeImageUrl = employee.EmployeeImageUrl
                };
                return output;
            }
            return null;
        }
        public bool Delete(Guid id)
        {
            var employee= _data.GetById(id);
            if (employee == null)
            {
                return false;
            }
            _data.Delete(employee);
            return true;
        }
    }
}
