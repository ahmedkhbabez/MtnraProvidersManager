using MtnraProvidersManager_BAL.Dtos.Market;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IMarketService
    {
        IEnumerable<MarketReadDto> GetMarkets();
        Market? GetMarketById(Guid id);
        MarketReadDto? GetMarketByReference(string reference);
        MarketReadDto Update(Market market);
        MarketReadDto Create(MarketWriteDto market, string by);
        void Delete(Market market);
    }
}
