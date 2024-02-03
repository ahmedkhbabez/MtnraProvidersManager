using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Market;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class MarketStateHistoryService : IMarketStateHistoryService
    {
        public readonly IRepository<MarketStateHistory> _repository;
        public readonly IMapper _mapper;
        public MarketStateHistoryService(IRepository<MarketStateHistory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void DeleteByMarket(Guid marketId)
        {
            var marketToDelete = _repository.GetOne(h => h.MarketId == marketId);
            while (marketToDelete != null)
            {
                _repository.Delete(marketToDelete);
                marketToDelete = _repository.GetOne(h => h.MarketId == marketId);
            }
        }

        public IEnumerable<MarketStateHistoryReadDto> GetByMarket(Guid marketId)
        {
            var all = _repository.GetAll();
            var filterd = all.Where(h => h.MarketId == marketId);
            return _mapper.Map<IEnumerable<MarketStateHistoryReadDto>>(filterd);
        }
    }
}
