using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.CommonRightContract;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class CommonRightContractService : MappingCompleter, ICommonRightContractService
    {
        private readonly IRepository<CommonRightContract> _repository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CommonRightContractService(
            IRepository<CommonRightContract> repository,
            IUserService userService,
            IMapper mapper,
            IDirectionService directionService,
            ICompanyService companyService,
            IChangesHandler changesHandler) : base(directionService, companyService)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        public CommonRightContractReadDto Create(CommonRightContractWriteDto crc, string by)
        {
            var mappedCommonRightContract = _mapper.Map<CommonRightContract>(crc);
            var currentUser = _userService.GetUserByUsermane(by);
            mappedCommonRightContract.Creator = currentUser;
            mappedCommonRightContract.AddedBy = currentUser!.Id;
            var createdCommonRightContract = _repository.Create(mappedCommonRightContract);
            var result = _mapper.Map<CommonRightContractReadDto>(createdCommonRightContract);
            result.Direction = CompleteDirectionMapping(result.Direction!.Id);
            result.Company = CompleteCompanyMapping(result.Company!.Id);
            return result;
        }
        public void Delete(CommonRightContract crc) => _repository.Delete(crc);

        public CommonRightContractReadDto? GetOneCommonRightContract(Guid id)
        {
            var crc = GetCommonRightContractById(id);
            if (crc == null)
                return null;
            var mappedCommonRightContract = _mapper.Map<CommonRightContractReadDto>(crc);
            mappedCommonRightContract.Direction = CompleteDirectionMapping(mappedCommonRightContract.Direction!.Id);
            mappedCommonRightContract.Company = CompleteCompanyMapping(mappedCommonRightContract.Company!.Id);
            return mappedCommonRightContract;
        }
        public CommonRightContract? GetCommonRightContractById(Guid id)
            => _repository.GetOne(po => po.Id == id);
        public IEnumerable<CommonRightContractReadDto> GetCommonRightContracts()
        {
            var purchaseOrders = _repository.GetAll();
            List<CommonRightContractReadDto> mapped = _mapper.Map<IEnumerable<CommonRightContractReadDto>>(purchaseOrders).ToList();
            foreach (var crc in mapped)
            {
                crc.Direction = CompleteDirectionMapping(crc.Direction!.Id);
                crc.Company = CompleteCompanyMapping(crc.Company!.Id);

            }

            return mapped;
        }
        public CommonRightContractReadDto Update(CommonRightContract crc)
        {
            _repository.Update(crc);
            var updated = GetCommonRightContractById(crc.Id);
            var result = _mapper.Map<CommonRightContractReadDto>(updated);
            result.Direction = CompleteDirectionMapping(result.Direction!.Id);
            result.Company = CompleteCompanyMapping(result.Company!.Id);
            return result;
        }
    }
}
