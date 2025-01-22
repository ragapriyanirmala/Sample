using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface IBranchServices
    {
        Task<List<BranchDTO>> Get(string? filteron = null, string? filterquery = null,
              string? sortby = null, bool isascending = true);
        Task<BranchDTO> GetById(Guid id);
        Task<BranchDTO> Create(AddBranchDTO input);
        Task<BranchDTO?> Update(Guid id, AddBranchDTO input);
        Task<bool> Delete(Guid id);
    }
}
