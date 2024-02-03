using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyReadDto>();
            CreateMap<CompanyReadDto, Company>();
            CreateMap<Company, CompanyWriteDto>();
            CreateMap<CompanyWriteDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();
            CreateMap<CompanyUpdateDto, Company>();
        }
    }
}
