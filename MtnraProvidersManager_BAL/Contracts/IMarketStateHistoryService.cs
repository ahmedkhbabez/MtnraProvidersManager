using MtnraProvidersManager_BAL.Dtos.Market;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IMarketStateHistoryService
    {
        void DeleteByMarket(Guid marketId);
        IEnumerable<MarketStateHistoryReadDto> GetByMarket(Guid marketId);
    }
}
