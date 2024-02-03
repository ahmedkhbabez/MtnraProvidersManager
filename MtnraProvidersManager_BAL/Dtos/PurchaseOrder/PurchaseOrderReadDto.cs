using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_DAL.Enums;

namespace MtnraProvidersManager_BAL.Dtos.PurchaseOrder
{
    public class PurchaseOrderReadDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public State? State { get; set; }
        public string Reference { get; set; } = string.Empty;
        public uint Year { get; set; } = (uint)DateTime.Now.Year;
        public CompanyReadDto? Company { get; set; }
        public DirectionReadDto? Direction { get; set; }
    }
}
