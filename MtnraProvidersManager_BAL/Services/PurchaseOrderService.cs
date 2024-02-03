using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.PurchaseOrder;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class PurchaseOrderService : MappingCompleter, IPurchaseOrderService
    {
        private readonly IRepository<PurchaseOrder> _repository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PurchaseOrderService(
            IRepository<PurchaseOrder> repository,
            IUserService userService,
            IMapper mapper,
            IDirectionService directionService,
            ICompanyService companyService) : base(directionService, companyService)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        public PurchaseOrderReadDto Create(PurchaseOrderWriteDto po, string by)
        {
            var mappedPurchaseOrder = _mapper.Map<PurchaseOrder>(po);
            var currentUser = _userService.GetUserByUsermane(by);
            mappedPurchaseOrder.Creator = currentUser;
            mappedPurchaseOrder.AddedBy = currentUser!.Id;
            var createdPurchaseOrder = _repository.Create(mappedPurchaseOrder);
            var result = _mapper.Map<PurchaseOrderReadDto>(createdPurchaseOrder);
            result.Direction = CompleteDirectionMapping(result.Direction!.Id);
            result.Company = CompleteCompanyMapping(result.Company!.Id);
            return result;
        }
        public void Delete(PurchaseOrder po)
            => _repository.Delete(po);

        public PurchaseOrderReadDto? GetOnePurchaseOrder(Guid id)
        {
            var po = GetPurchaseOrderById(id);
            if (po == null)
                return null;
            var mappedPurchaseOrder = _mapper.Map<PurchaseOrderReadDto>(po);
            mappedPurchaseOrder.Direction = CompleteDirectionMapping(mappedPurchaseOrder.Direction!.Id);
            mappedPurchaseOrder.Company = CompleteCompanyMapping(mappedPurchaseOrder.Company!.Id);
            return mappedPurchaseOrder;
        }
        public PurchaseOrder? GetPurchaseOrderById(Guid id)
            => _repository.GetOne(po => po.Id == id);
        public IEnumerable<PurchaseOrderReadDto> GetPurchaseOrders()
        {
            var purchaseOrders = _repository.GetAll();
            List<PurchaseOrderReadDto> mapped = _mapper.Map<IEnumerable<PurchaseOrderReadDto>>(purchaseOrders).ToList();
            foreach (var po in mapped)
            {
                po.Direction = CompleteDirectionMapping(po.Direction!.Id);
                po.Company = CompleteCompanyMapping(po.Company!.Id);

            }

            return mapped;
        }
        public PurchaseOrderReadDto Update(PurchaseOrder po)
        {
            _repository.Update(po);
            var updated = GetPurchaseOrderById(po.Id);
            var result = _mapper.Map<PurchaseOrderReadDto>(updated);
            result.Direction = CompleteDirectionMapping(result.Direction!.Id);
            result.Company = CompleteCompanyMapping(result.Company!.Id);
            return result;
        }
    }
}
