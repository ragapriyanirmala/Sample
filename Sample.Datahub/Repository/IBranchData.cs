using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public interface IBranchData
    {
        Task<List<Branch>> GetBranchDatas();
        Task<Branch> GetById(Guid id);
        Task<Branch> Create(Branch branch);
        Task<Guid?> GetBranchIdByCode(string code);
        Task<Branch> Update(Branch branch);
        void Delete(Branch branch);
    }
}
