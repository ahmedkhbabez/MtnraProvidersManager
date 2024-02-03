using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/directions")]
    [Authorize]
    public class DirectionController : ControllerBase
    {
        private readonly IDirectionService _directionService;
        private readonly IInterlocutorService _interlocutorService;
        private readonly IChangesHandler _changesHandler;

        public DirectionController(
            IDirectionService directionService,
            IInterlocutorService interlocutorService,
            IChangesHandler changesHandler)
        {
            _directionService = directionService;
            _interlocutorService = interlocutorService;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DirectionReadDto>> GetAll()
        {
            var directions = _directionService.GetDirections();
            return directions == null ? (ActionResult<IEnumerable<DirectionReadDto>>)NotFound() : (ActionResult<IEnumerable<DirectionReadDto>>)Ok(directions);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<DirectionReadDto> GetById(Guid id)
        {
            var direction = _directionService.GetOneDirection(id);
            return direction == null ? (ActionResult<DirectionReadDto>)NotFound() : (ActionResult<DirectionReadDto>)Ok(direction);
        }

        [HttpPost]
        public ActionResult<DirectionReadDto> Create(DirectionWriteDto direction)
        {
            var currentUser = User.Identity!.Name;
            var newDirection = _directionService.Create(direction, by: currentUser!);
            return newDirection == null ? (ActionResult<DirectionReadDto>)BadRequest() : (ActionResult<DirectionReadDto>)Ok(newDirection);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<DirectionReadDto> Update(Guid id, [FromBody] DirectionUpdateDto request)
        {
            var direction = _directionService.GetDirectionById(id);
            if (direction == null)
                return NotFound();
            if (request.Abbreviation != null)
                direction.Abbreviation = request.Abbreviation;
            if (request.ExtendedName != null)
                direction.ExtendedName = request.ExtendedName;
            var interlocutor = _interlocutorService.GetInterlocutorById(request.InterlocutorId);
            if (interlocutor != null)
            {
                direction.Interlocutor = interlocutor;
                direction.InterlocutorId = interlocutor.Id;
            }

            direction.UpdatedOn = DateTime.Now;
            var updatedDirection = _directionService.Update(direction);
            return updatedDirection == null ? (ActionResult<DirectionReadDto>)BadRequest() : (ActionResult<DirectionReadDto>)Ok(updatedDirection);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var direction = _directionService.GetDirectionById(id);
            if (direction == null)
                return NotFound();
            _directionService.Delete(direction);
            _changesHandler.Save();
            var deletedDirection = _directionService.GetDirectionById(id);
            return deletedDirection != null ? BadRequest() : Ok();
        }
    }
}
