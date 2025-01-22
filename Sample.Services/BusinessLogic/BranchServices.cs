using AutoMapper;
using Sample.Datahub.Models.Domain;
using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Services.BusinessLogic
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchData _data;
        private readonly IMapper _mapper;
        public BranchServices(IBranchData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        public async Task<List<BranchDTO>> Get(string? filteron = null, string? filterquery = null,
             string? sortby = null, bool isascending = true)
        {
            var branches = await _data.GetBranchDatas();
            if (!string.IsNullOrWhiteSpace(filteron) && !string.IsNullOrWhiteSpace(filterquery))
            {
                if (filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    branches = branches.Where(x => x.Name.ToLower().Contains(filterquery.ToLower())).ToList();
                }
                if (filteron.Equals("Code", StringComparison.OrdinalIgnoreCase))
                {
                    branches = branches.Where(x => x.Code.ToLower().Contains(filterquery.ToLower())).ToList();
                }
            }
            if (!string.IsNullOrWhiteSpace(sortby))
            {
                if (sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    branches = isascending ? branches.OrderBy(x => x.Name).ToList()
                        : branches.OrderByDescending(x => x.Name).ToList();
                }
            }
            return _mapper.Map<List<BranchDTO>>(branches);
        }
        public async Task<BranchDTO> GetById(Guid id)
        {
            var branchdata = await _data.GetById(id);
            var branch = new BranchDTO()
            {
                Id = branchdata.Id,
                Name = branchdata.Name,
                Code = branchdata.Code,
                BranchImageUrl = branchdata.BranchImageUrl
            };
            return branch;
        }
        public async Task<BranchDTO> Create(AddBranchDTO input)
        {
            var branch = new Branch()
            {
                Name = input.Name,
                Code = input.Code,
                BranchImageUrl = input.BranchImageurl
            };
            branch = await _data.Create(branch);
            var output = new BranchDTO()
            {
                Id = branch.Id,
                Name = branch.Name,
                Code = branch.Code,
                BranchImageUrl = branch.BranchImageUrl
            };
            return output;
        }
        public async Task<BranchDTO?> Update(Guid id, AddBranchDTO input)
        {
            var branch = await _data.GetById(id);
            if (branch == null)
            {
                return null;
            }
            branch.Name = input.Name;
            branch.Code = input.Code;
            branch.BranchImageUrl = input.BranchImageurl;
            branch = await _data.Update(branch);
            var output = new BranchDTO()
            {
                Id = branch.Id,
                Name = branch.Name,
                Code = branch.Code,
                BranchImageUrl = branch.BranchImageUrl
            };
            return output;
        }
        public async Task<bool> Delete(Guid id)
        {
            var branch = await _data.GetById(id);
            if (branch == null)
            {
                return false;
            }
            _data.Delete(branch);
            return true;
        }
    }
}
