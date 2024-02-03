using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.Market
{
    public class MarketWriteDto
    {
        public string Reference { get; set; } = string.Empty;
        public string Object { get; set; } = string.Empty;
        public State State { get; set; }
        public double Estimation { get; set; }
        public DateTime LaunchedAt { get; set; }
        public DateTime WarrantyDeadline { get; set; }
        public DateTime ProvisionalReception { get; set; }
        public DateTime DefinitiveReception { get; set; }
        public uint Year { get; set; }
        public MarketNature Nature { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DirectionId { get; set; }
        public Guid? OriginalInvitationToTenderId { get; set; }
    }
}
