using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public class BranchData : IBranchData
    {
        private readonly SampleDbContext _context;
        #region --constructor
        public BranchData(SampleDbContext context)
        {
            _context = context;
        }
        #endregion
        #region --methods
        public List<Branch> GetBranchDatas()
        {
            var branchdata = _context.Branches.ToList();
            return branchdata;
        }
        public Branch GetById(Guid id)
        {
            var branch = _context.Branches.FirstOrDefault(x => x.Id == id);
            return branch;
        }
        #endregion
    }
}
