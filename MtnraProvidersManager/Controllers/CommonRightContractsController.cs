using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.CommonRightContract;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/common-right-contracts")]
    [Authorize]
    public class CommonRightContractsController : ControllerBase
    {
        private readonly ICommonRightContractService _crcService;
        private readonly IDirectionService _directionService;
        private readonly ICompanyService _companyService;
        private readonly IChangesHandler _changesHandler;

        public CommonRightContractsController(
            ICommonRightContractService crcService,
            IDirectionService directionService,
            ICompanyService companyService,
            IChangesHandler changesHandler)
        {
            _crcService = crcService;
            _directionService = directionService;
            _companyService = companyService;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommonRightContractReadDto>> GetAll()
        {
            var crcs = _crcService.GetCommonRightContracts();
            return crcs == null ? (ActionResult<IEnumerable<CommonRightContractReadDto>>)NotFound() : (ActionResult<IEnumerable<CommonRightContractReadDto>>)Ok(crcs);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<CommonRightContractReadDto> GetById(Guid id)
        {
            var crc = _crcService.GetOneCommonRightContract(id);
            return crc == null ?
                    NotFound() :
                    Ok(crc);
        }

        [HttpPost]
        public ActionResult<CommonRightContractReadDto> Create(CommonRightContractWriteDto crc)
        {
            var currentUser = User.Identity!.Name;
            var newCommonRightContract = _crcService.Create(crc, by: currentUser!);
            return newCommonRightContract == null ?
                    BadRequest() :
                    Ok(newCommonRightContract);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<CommonRightContractReadDto> Update(Guid id, [FromBody] CommonRightContractUpdateDto request)
        {
            var crc = _crcService.GetCommonRightContractById(id);
            if (crc == null)
                return NotFound();
            crc.Year = request.Year ?? crc.Year;
            crc.Reference = request.Reference ?? crc.Reference;
            crc.Amount = request.Amount ?? crc.Amount;
            crc.State = request.State ?? crc.State;
            if (request.DirectionId != null)
            {
                var direction = _directionService.GetDirectionById((Guid)request.DirectionId);
                if (direction == null)
                {
                    return BadRequest();
                }

                crc.Direction = direction;
                crc.DirectionId = direction.Id;
            }

            if (request.CompanyId != null)
            {
                var company = _companyService.GetCompanyById((Guid)request.CompanyId);
                if (company == null)
                {
                    return BadRequest();
                }

                crc.Company = company;
                crc.CompanyId = company.Id;
            }

            crc.UpdatedOn = DateTime.Now;
            var updatedCommonRightContract = _crcService.Update(crc);
            return updatedCommonRightContract == null ?
                BadRequest() :
                Ok(updatedCommonRightContract);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var crc = _crcService.GetCommonRightContractById(id);
            if (crc == null)
                return NotFound();
            _crcService.Delete(crc);
            _changesHandler.Save();
            var deletedCommonRightContract = _crcService.GetCommonRightContractById(id);
            return deletedCommonRightContract != null ? BadRequest() : Ok();
        }
    }
}
