using AutoMapper;
using Sample.Datahub.Models.Domain;
using Sample.Services.DTOs;

namespace Sample.Services.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AddEmployeeDTO, Employee>()
                //.ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.Name)) --
                .ReverseMap();
            CreateMap<Employee, EmpolyeeDTO>().ReverseMap();
            CreateMap<Branch,BranchDTO>().ReverseMap();
        }
    }
}
