using AutoMapper;
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
        private readonly IMapper _mapper;
        public EmployeeServices(IEmployeeData data, IBranchData branchdata,
            ITeamData teamData, IMapper mapper)
        {
            _data = data;
            _branchData = branchdata;
            _teamData = teamData;
            _mapper = mapper;
        }
        public List<EmpolyeeDTO> Get(string? filteron = null, string? filterquery = null,
             string? sortby = null, bool isascending = true)
        {
            var employees = _data.Get();
            if (!string.IsNullOrWhiteSpace(filteron) && !string.IsNullOrWhiteSpace(filterquery))
            {
                if (filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    employees = employees.Where(x => x.Name.ToLower().Contains(filterquery.ToLower())).ToList();
                }
                if (filteron.Equals("BranchName", StringComparison.OrdinalIgnoreCase))
                {
                    employees = employees.Where(x => x.Branch.Name.ToLower().Contains(filterquery.ToLower())).ToList();
                }                
            }
            if (!string.IsNullOrWhiteSpace(sortby))
            {
                if (sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    //employees = isascending ? employees.OrderBy(x => x.Name).ToList() :
                    //    employees.OrderByDescending(x => x.Name).ToList();
                    if (isascending)
                        employees = employees.OrderBy(x => x.Name).ToList();
                    else
                        employees = employees.OrderByDescending(x => x.Name).ToList();
                }
            }
            return _mapper.Map<List<EmpolyeeDTO>>(employees);
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
            var branchid = await _branchData.GetBranchIdByCode(input.BranchCode);
            var teamid = _teamData.GetTeamIdByName(input.TeamName);
            if (branchid != null && teamid != null)
            {
                //var employee = new Employee()
                //{
                //    Name = input.Name,
                //    Address = input.Address,
                //    EmployeeImageUrl = input.EmployeeImageUrl,
                //    BranchId = branchid.Value,
                //    TeamId = teamid.Value
                //};

                //Map DTOs to Model
                var employee = _mapper.Map<Employee>(input);
                employee.BranchId = branchid.Value;
                employee.TeamId = teamid.Value;

                employee = _data.Create(employee);

                //var output = new EmpolyeeDTO()
                //{
                //    Id = employee.Id,
                //    Name = employee.Name,
                //    Address = employee.Address,
                //    EmployeeImageUrl = employee.EmployeeImageUrl
                //};

                //Map Models to DTOs
                var output = _mapper.Map<EmpolyeeDTO>(employee);
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
                employee.BranchId = branchid.Result.Value;
                employee.TeamId = teamid.Value;
                employee.Name = input.Name;
                employee.Address = input.Address;
                employee.EmployeeImageUrl = input.EmployeeImageUrl;
                employee = _data.Update(employee);
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
            var employee = _data.GetById(id);
            if (employee == null)
            {
                return false;
            }
            _data.Delete(employee);
            return true;
        }
    }
}
