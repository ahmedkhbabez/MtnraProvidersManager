using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyReadDto> GetCompanies();
        Company? GetCompanyById(Guid id);
        CompanyReadDto? GetOneCompany(Guid id);
        CompanyReadDto Update(Company company);
        CompanyReadDto Create(CompanyWriteDto company, string by);
        void Delete(Company company);
    }
}
