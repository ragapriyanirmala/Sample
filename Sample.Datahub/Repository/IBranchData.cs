using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public interface IBranchData
    {
        List<Branch> GetBranchDatas();
        Branch GetById(Guid id);
        Branch Create(Branch branch);
        Guid? GetBranchIdByCode(string code);
    }
}
