using MtnraProvidersManager_BAL.Dtos.PurchaseOrder;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IPurchaseOrderService
    {
        IEnumerable<PurchaseOrderReadDto> GetPurchaseOrders();
        PurchaseOrder? GetPurchaseOrderById(Guid id);
        PurchaseOrderReadDto? GetOnePurchaseOrder(Guid id);
        PurchaseOrderReadDto Update(PurchaseOrder po);
        PurchaseOrderReadDto Create(PurchaseOrderWriteDto po, string by);
        void Delete(PurchaseOrder po);
    }
}
