using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IRepository<Company> _repository;
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		public CompanyService(
			IRepository<Company> repository,
			IMapper mapper,
			IUserService userService)
		{
			_repository = repository;
			_mapper = mapper;
			_userService = userService;
		}

		public CompanyReadDto Create(CompanyWriteDto company, string by)
		{
			var companyEntity = _mapper.Map<Company>(company);
			var currentUser = _userService.GetUserByUsermane(by);
			companyEntity.AddedBy = currentUser!.Id;
			companyEntity.Creator = currentUser;
			var createdCompany = _repository.Create(companyEntity);
			return _mapper.Map<CompanyReadDto>(createdCompany);
		}

		public void Delete(Company company) => _repository.Delete(company);

		public IEnumerable<CompanyReadDto> GetCompanies()
		{
			var companies = _repository.GetAll();
			return _mapper.Map<IEnumerable<CompanyReadDto>>(companies);
		}

		public Company? GetCompanyById(Guid id)
		   => _repository.GetOne(company => company.Id == id);

		public CompanyReadDto? GetOneCompany(Guid id)
		{
			var company = GetCompanyById(id);
			return _mapper.Map<CompanyReadDto>(company);
		}

		public CompanyReadDto Update(Company company)
		{
			_repository.Update(company);
			return GetOneCompany(company.Id)!;
		}
	}
}
