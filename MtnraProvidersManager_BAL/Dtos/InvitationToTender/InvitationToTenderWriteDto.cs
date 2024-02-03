using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.InvitationToTender
{
    public class InvitationToTenderWriteDto
    {
        public string Object { get; set; } = string.Empty;
        public bool HasLaunched { get; set; }
        public string Reference { get; set; } = string.Empty;
        public uint Year { get; set; }
        public bool IsReservedForSme { get; set; }
        public Trimester Trimester { get; set; }
        public MarketNature Nature { get; set; }
        public string ExecutionLocation { get; set; } = string.Empty;
        public DateTime OpenedOn { get; set; }
        public Guid DirectionId { get; set; }
    }
}
