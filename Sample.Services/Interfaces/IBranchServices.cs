using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface IBranchServices
    {
        List<BranchDTO> Get();
        BranchDTO GetById(Guid id);
        BranchDTO Create(AddBranchDTO input);
        BranchDTO? Update(Guid id, AddBranchDTO input);
    }
}
