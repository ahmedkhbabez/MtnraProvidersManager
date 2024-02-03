using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/interlocutors")]
    [Authorize]
    public class InterlocutorsController : ControllerBase
    {
        private readonly IInterlocutorService _interlocutorService;
        private readonly IChangesHandler _changesHandler;

        public InterlocutorsController(
            IInterlocutorService interlocutorService,
            IChangesHandler changesHandler)
        {
            _interlocutorService = interlocutorService;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InterlocutorReadDto>> GetAll()
        {
            var interlocutors = _interlocutorService.GetInterlocutors();
            return interlocutors == null ? (ActionResult<IEnumerable<InterlocutorReadDto>>)NotFound() : (ActionResult<IEnumerable<InterlocutorReadDto>>)Ok(interlocutors);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<InterlocutorReadDto> GetById(Guid id)
        {
            var interlocutor = _interlocutorService.GetOneInterlocutor(id);
            return interlocutor == null ? (ActionResult<InterlocutorReadDto>)NotFound() : (ActionResult<InterlocutorReadDto>)Ok(interlocutor);
        }

        [HttpPost]
        public ActionResult<InterlocutorReadDto> Create(InterlocutorWriteDto interlocutor)
        {
            var currentUser = User.Identity!.Name;
            var newInterlocutor = _interlocutorService.Create(interlocutor, by: currentUser!);
            return newInterlocutor == null ? (ActionResult<InterlocutorReadDto>)BadRequest() : (ActionResult<InterlocutorReadDto>)Ok(newInterlocutor);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<InterlocutorReadDto> Update(Guid id, [FromBody] InterlocutorUpdateDto request)
        {
            var interlocutor = _interlocutorService.GetInterlocutorById(id);
            if (interlocutor == null)
                return NotFound();
            if (request.FirstName.Length > 3)
                interlocutor.FirstName = request.FirstName;
            if (request.LastName.Length > 3)
                interlocutor.LastName = request.LastName;
            interlocutor.UpdatedOn = DateTime.Now;
            var updatedInterlocutor = _interlocutorService.Update(interlocutor);
            return updatedInterlocutor == null ? (ActionResult<InterlocutorReadDto>)BadRequest() : (ActionResult<InterlocutorReadDto>)Ok(updatedInterlocutor);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var interlocutor = _interlocutorService.GetInterlocutorById(id);
            if (interlocutor == null)
                return NotFound();
            _interlocutorService.Delete(interlocutor);
            _changesHandler.Save();
            var deletedInterlocutor = _interlocutorService.GetInterlocutorById(id);
            return deletedInterlocutor != null ? BadRequest() : Ok();
        }
    }
}
