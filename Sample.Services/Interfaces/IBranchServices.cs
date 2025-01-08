using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface IBranchServices
    {
        Task<List<BranchDTO>> Get();
        Task<BranchDTO> GetById(Guid id);
        Task<BranchDTO> Create(AddBranchDTO input);
        Task<BranchDTO?> Update(Guid id, AddBranchDTO input);
        Task<bool> Delete(Guid id);
    }
}
