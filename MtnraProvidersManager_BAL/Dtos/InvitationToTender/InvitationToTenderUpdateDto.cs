using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.InvitationToTender
{
    public class InvitationToTenderUpdateDto
    {
        public string? Object { get; set; }
        public bool? HasLaunched { get; set; }
        public string? Reference { get; set; }
        public uint? Year { get; set; }
        public bool? IsReservedForSme { get; set; }
        public Trimester? Trimester { get; set; }
        public MarketNature? Nature { get; set; }
        public string? ExecutionLocation { get; set; }
        public DateTime? OpenedOn { get; set; }
        public Guid? DirectionId { get; set; }
    }
}
