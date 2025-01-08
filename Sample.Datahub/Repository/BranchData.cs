using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Branch>> GetBranchDatas()
        {
            var branchdata = await _context.Branches.ToListAsync();
            return branchdata;
        }
        public async Task<Branch> GetById(Guid id)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(x => x.Id == id);
            return branch;
        }
        public async Task<Branch> Create(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            return branch;
        }
        public async Task<Guid?> GetBranchIdByCode(string code)
        {

            var branch = await _context.Branches.FirstOrDefaultAsync(x => x.Code == code);
            if (branch != null)
            {
                return branch.Id;
            }
            return null;

        }
        public async Task<Branch> Update(Branch branch)
        {
            await _context.SaveChangesAsync();
            return branch;
        }
        public async void Delete(Branch branch)
        {
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
