using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;

namespace MtnraProvidersManager_BAL.Services
{
    public class MappingCompleter
    {
        private readonly IDirectionService _directionService;
        private readonly ICompanyService _companyService;

        public MappingCompleter(IDirectionService directionService,
                                ICompanyService companyService)
        {
            _directionService = directionService;
            _companyService = companyService;
        }

        public DirectionReadDto CompleteDirectionMapping(Guid id)
           => _directionService.GetOneDirection(id)!;
        public CompanyReadDto CompleteCompanyMapping(Guid id)
            => _companyService.GetOneCompany(id)!;
    }
}
