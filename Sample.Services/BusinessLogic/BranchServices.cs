﻿using Sample.Datahub.Models.Domain;
using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Services.BusinessLogic
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchData _data;
        public BranchServices(IBranchData data)
        {
            _data = data;
        }
        public List<BranchDTO> Get()
        {
            var branchdata = _data.GetBranchDatas();
            var branches = new List<BranchDTO>();
            foreach (var branch in branchdata)
            {
                branches.Add(new BranchDTO()
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Code = branch.Code,
                    BranchImageUrl = branch.BranchImageUrl
                });
            }
            return branches;
        }
        public BranchDTO GetById(Guid id)
        {
            var branchdata = _data.GetById(id);
            var branch = new BranchDTO()
            {
                Id = branchdata.Id,
                Name = branchdata.Name,
                Code = branchdata.Code,
                BranchImageUrl = branchdata.BranchImageUrl
            };
            return branch;
        }
        public BranchDTO Create(AddBranchDTO input)
        {
            var branch = new Branch()
            {
                Name = input.Name,
                Code = input.Code,
                BranchImageUrl = input.BranchImageurl
            };
            branch = _data.Create(branch);
            var output = new BranchDTO()
            {
                Name = branch.Name,
                Code = branch.Code,
                BranchImageUrl = branch.BranchImageUrl
            };
            return output;
        }
    }
}
