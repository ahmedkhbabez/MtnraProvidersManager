using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.CommonRightContract
{
    public class CommonRightContractWriteDto
    {
        public double Amount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public uint Year { get; set; } = (uint)DateTime.Now.Year;
        public State? State { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DirectionId { get; set; }
    }
}
