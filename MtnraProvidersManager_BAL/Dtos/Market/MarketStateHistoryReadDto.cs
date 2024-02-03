using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.Market
{
    public class MarketStateHistoryReadDto
    {
        public State State { get; set; }
        public DateTime Date { get; set; }
    }
}
