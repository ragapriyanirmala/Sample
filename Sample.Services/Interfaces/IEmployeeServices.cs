using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface IEmployeeServices
    {
        List<EmpolyeeDTO> Get();
        EmpolyeeDTO GetById(Guid id);
        Task<EmpolyeeDTO> Create(AddEmployeeDTO input);
        EmpolyeeDTO Update(Guid id, AddEmployeeDTO input);
        bool Delete(Guid id);
    }
}
