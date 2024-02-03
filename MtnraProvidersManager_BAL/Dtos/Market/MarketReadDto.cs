using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.Market
{
    public class MarketReadDto
    {
        public Guid Id { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Object { get; set; } = string.Empty;
        public State State { get; set; }
        public double Estimation { get; set; }
        public DateTime LaunchedAt { get; set; }
        public DateTime ProvisionalReception { get; set; }
        public DateTime DefinitiveReception { get; set; }
        public DateTime WarrantyDeadline { get; set; }
        public uint Year { get; set; }
        public MarketNature Nature { get; set; }
        public CompanyReadDto? Company { get; set; }
        public DirectionReadDto? Direction { get; set; }
        public InvitationToTenderReadDto? OriginalInvitationToTender { get; set; }
    }
}
