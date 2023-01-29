using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;

namespace Hali.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyWithUserCreateDto, Company>().ReverseMap();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Process, ProcessDto>();
            CreateMap<ProcessCreateDto, Process>();
            CreateMap<ProcessUpdateDto, Process>();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser, CompanyWithUserDto>();
                //.ForMember(dest => dest.Id, opt =>
                //    opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Company, opt =>
                //    opt.MapFrom(src => src.Company));
        }
    }
}
