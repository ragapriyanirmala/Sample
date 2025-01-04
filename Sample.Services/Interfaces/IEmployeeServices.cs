using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface IEmployeeServices
    {
        List<EmpolyeeDTO> Get();
        EmpolyeeDTO GetById(Guid id);
        EmpolyeeDTO Create(AddEmployeeDTO input);
    }
}
