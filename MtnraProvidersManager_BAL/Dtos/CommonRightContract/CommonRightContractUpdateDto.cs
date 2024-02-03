using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.CommonRightContract
{
    public class CommonRightContractUpdateDto
    {
        public double? Amount { get; set; }
        public string? Reference { get; set; }
        public State? State { get; set; }
        public uint? Year { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? DirectionId { get; set; }
    }
}
