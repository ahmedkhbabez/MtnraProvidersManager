using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Market;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/markets")]
    [Authorize]
    public class MarketsController : ControllerBase
    {
        private readonly IMarketService _service;
        private readonly IMarketStateHistoryService _stateHistoryService;
        private readonly IChangesHandler _changesHandler;

        public MarketsController(IMarketService service, IMarketStateHistoryService stateHistoryService, IChangesHandler changesHandler)
        {
            _service = service;
            _stateHistoryService = stateHistoryService;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarketReadDto>> GetAll()
        {
            var markets = _service.GetMarkets();
            return markets == null ? (ActionResult<IEnumerable<MarketReadDto>>)NotFound() : (ActionResult<IEnumerable<MarketReadDto>>)Ok(markets);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<MarketReadDto> GetById(Guid id)
        {
            var market = _service.GetMarketById(id);
            return market == null ? (ActionResult<MarketReadDto>)NotFound() : (ActionResult<MarketReadDto>)Ok(market);
        }

        [HttpGet("{id:guid}/state-history")]
        public ActionResult<IEnumerable<MarketStateHistoryReadDto>> GetStateHistoryById(Guid id)
        {
            var history = _stateHistoryService.GetByMarket(id);
            return history == null ? (ActionResult<IEnumerable<MarketStateHistoryReadDto>>)NotFound() : (ActionResult<IEnumerable<MarketStateHistoryReadDto>>)Ok(history);
        }

        [HttpPost]
        public ActionResult<MarketReadDto> Create(MarketWriteDto market)
        {
            if (string.IsNullOrEmpty(market.Reference))
                return BadRequest();
            var exists = _service.GetMarketByReference(market.Reference);
            if (exists != null)
                return BadRequest();
            var currentUser = User.Identity!.Name;
            var created = _service.Create(market, by: currentUser!);
            return created == null ? (ActionResult<MarketReadDto>)BadRequest() : (ActionResult<MarketReadDto>)Ok(created);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<MarketReadDto> Update(Guid id, [FromBody] MarketUpdateDto request)
        {
            var market = _service.GetMarketById(id);
            if (market == null)
                return NotFound();

            market.UpdatedOn = DateTime.Now;
            if (!string.IsNullOrEmpty(request.Reference))
            {
                var existed = _service.GetMarketByReference(request.Reference);
                if (existed != null && existed.Id != id)
                    return BadRequest();
                market.Reference = request.Reference;
            }

            market.DefinitiveReception = request.DefinitiveReception ?? market.DefinitiveReception;
            market.ProvisionalReception = request.ProvisionalReception ?? market.ProvisionalReception;
            market.Object = request.Object ?? market.Object;
            market.Year = request.Year ?? market.Year;
            market.WarrantyDeadline = request.WarrantyDeadline ?? market.WarrantyDeadline;
            market.CompanyId = request.CompanyId ?? market.CompanyId;
            market.DirectionId = request.DirectionId ?? market.DirectionId;
            market.Estimation = request.Estimation ?? market.Estimation;
            market.State = request.State ?? market.State;
            market.Nature = request.Nature ?? market.Nature;
            market.LaunchedAt = request.LaunchedAt ?? market.LaunchedAt;
            var updated = _service.Update(market);
            return updated == null ? (ActionResult<MarketReadDto>)BadRequest() : (ActionResult<MarketReadDto>)Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<MarketReadDto> Delete(Guid id)
        {
            var market = _service.GetMarketById(id);
            if (market == null)
                return NotFound();
            _service.Delete(market);
            _changesHandler.Save();
            var deleted = _service.GetMarketById(id);
            return deleted != null ? (ActionResult<MarketReadDto>)BadRequest() : (ActionResult<MarketReadDto>)Ok();
        }

    }
}
