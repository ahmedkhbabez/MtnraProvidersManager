using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_BAL.Dtos.Market;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class MarketService : MappingCompleter, IMarketService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Market> _repository;
        private readonly IInvitationToTenderService _invitationToTenderService;
        private readonly IUserService _userService;

        public MarketService(
            IMapper mapper,
            IRepository<Market> repository,
            IDirectionService directionService,
            IInvitationToTenderService invitationToTenderService,
            ICompanyService companyService,
            IUserService userService) : base(directionService, companyService)
        {
            _mapper = mapper;
            _repository = repository;
            _invitationToTenderService = invitationToTenderService;
            _userService = userService;
        }

        private InvitationToTenderReadDto? CompleteInvitationToTenderMapping(MarketReadDto source)
            => source.OriginalInvitationToTender!.Id != Guid.Empty ?
            _invitationToTenderService.GetOneInvitationToTender(source.OriginalInvitationToTender.Id)! :
            null;
        private MarketReadDto CompleteMappings(MarketReadDto incomplete)
        {
            incomplete.Company = CompleteCompanyMapping(incomplete.Company!.Id);
            incomplete.Direction = CompleteDirectionMapping(incomplete.Direction!.Id);
            incomplete.OriginalInvitationToTender = CompleteInvitationToTenderMapping(incomplete);
            return incomplete;
        }

        public MarketReadDto Create(MarketWriteDto market, string by)
        {
            var newMarket = _mapper.Map<Market>(market);
            var currentUser = _userService.GetUserByUsermane(by);
            newMarket.Creator = currentUser;
            newMarket.AddedBy = currentUser!.Id;
            var created = _repository.Create(newMarket);
            var mapped = _mapper.Map<MarketReadDto>(created);
            return CompleteMappings(mapped);
        }

        public void Delete(Market market) => _repository.Delete(market);

        public Market? GetMarketById(Guid id)
            => _repository.GetOne(m => m.Id == id);

        public IEnumerable<MarketReadDto> GetMarkets()
        {
            var markets = _repository.GetAll();
            var mapped = _mapper.Map<IEnumerable<MarketReadDto>>(markets);
            foreach (var market in mapped)
            {
                market.Direction = CompleteDirectionMapping(market.Direction!.Id);
                market.Company = CompleteCompanyMapping(market.Company!.Id);
                market.OriginalInvitationToTender = CompleteInvitationToTenderMapping(market);
            }

            return mapped;
        }

        public MarketReadDto? GetMarketByReference(string reference)
        {
            var market = _repository.GetOne(m => m.Reference == reference);
            return market == null ? null : CompleteMappings(_mapper.Map<MarketReadDto>(market));
        }

        public MarketReadDto Update(Market market)
        {
            _repository.Update(market);
            return CompleteMappings(_mapper.Map<MarketReadDto>(GetMarketById(market.Id)));
        }

    }

}
