using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.PurchaseOrder;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/purchase-orders")]
    [Authorize]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IDirectionService _directionService;
        private readonly ICompanyService _companyService;
        private readonly IChangesHandler _changesHandler;

        public PurchaseOrdersController(
            IPurchaseOrderService purchaseOrderService,
            IDirectionService directionService,
            ICompanyService companyService,
            IChangesHandler changesHandler)
        {
            _purchaseOrderService = purchaseOrderService;
            _directionService = directionService;
            _companyService = companyService;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseOrderReadDto>> GetAll()
        {
            var purchaseOrders = _purchaseOrderService.GetPurchaseOrders();
            return purchaseOrders == null ? (ActionResult<IEnumerable<PurchaseOrderReadDto>>)NotFound() : (ActionResult<IEnumerable<PurchaseOrderReadDto>>)Ok(purchaseOrders);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<PurchaseOrderReadDto> GetById(Guid id)
        {
            var purchaseOrder = _purchaseOrderService.GetOnePurchaseOrder(id);
            return purchaseOrder == null ?
                    NotFound() :
                    Ok(purchaseOrder);
        }

        [HttpPost]
        public ActionResult<PurchaseOrderReadDto> Create(PurchaseOrderWriteDto purchaseOrder)
        {
            var currentUser = User.Identity!.Name;
            var newPurchaseOrder = _purchaseOrderService.Create(purchaseOrder, by: currentUser!);
            return newPurchaseOrder == null ?
                    BadRequest() :
                    Ok(newPurchaseOrder);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<PurchaseOrderReadDto> Update(Guid id, [FromBody] PurchaseOrderUpdateDto request)
        {
            var purchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            if (purchaseOrder == null)
                return NotFound();
            purchaseOrder.Year = request.Year ?? purchaseOrder.Year;
            purchaseOrder.Reference = request.Reference ?? purchaseOrder.Reference;
            purchaseOrder.Amount = request.Amount ?? purchaseOrder.Amount;
            purchaseOrder.State = request.State ?? purchaseOrder.State;
            if (request.DirectionId != null)
            {
                var direction = _directionService.GetDirectionById((Guid)request.DirectionId);
                if (direction == null)
                {
                    return BadRequest();
                }

                purchaseOrder.Direction = direction;
                purchaseOrder.DirectionId = direction.Id;
            }

            if (request.CompanyId != null)
            {
                var company = _companyService.GetCompanyById((Guid)request.CompanyId);
                if (company == null)
                {
                    return BadRequest();
                }

                purchaseOrder.Company = company;
                purchaseOrder.CompanyId = company.Id;
            }

            purchaseOrder.UpdatedOn = DateTime.Now;
            var updatedPurchaseOrder = _purchaseOrderService.Update(purchaseOrder);
            return updatedPurchaseOrder == null ?
                BadRequest() :
                Ok(updatedPurchaseOrder);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var purchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            if (purchaseOrder == null)
                return NotFound();
            _purchaseOrderService.Delete(purchaseOrder);
            _changesHandler.Save();
            var deletedPurchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            return deletedPurchaseOrder != null ? BadRequest() : Ok();
        }
    }
}
