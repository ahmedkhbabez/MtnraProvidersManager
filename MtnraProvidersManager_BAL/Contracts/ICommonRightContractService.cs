using MtnraProvidersManager_BAL.Dtos.CommonRightContract;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface ICommonRightContractService
    {
        IEnumerable<CommonRightContractReadDto> GetCommonRightContracts();
        CommonRightContract? GetCommonRightContractById(Guid id);
        CommonRightContractReadDto? GetOneCommonRightContract(Guid id);
        CommonRightContractReadDto? Update(CommonRightContract crc);
        CommonRightContractReadDto? Create(CommonRightContractWriteDto crc, string by);
        void Delete(CommonRightContract crc);
    }
}
