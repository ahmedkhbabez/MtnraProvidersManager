using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.InvitationToTender
{
    public class InvitationToTenderReadDto
    {
        public Guid Id { get; set; }
        public string Object { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public uint Year { get; set; }
        public bool HasLaunched { get; set; }
        public bool IsReservedForSme { get; set; }
        public Trimester Trimester { get; set; }
        public MarketNature Nature { get; set; }
        public string ExecutionLocation { get; set; } = string.Empty;
        public DateTime OpenedOn { get; set; }
        public DirectionReadDto? Direction { get; set; }
    }
}
