using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/invitations")]
    [Authorize]
    public class InvitationsToTenderController : ControllerBase
    {
        private readonly IInvitationToTenderService _service;
        private readonly IChangesHandler _changesHandler;

        public InvitationsToTenderController(
            IInvitationToTenderService service,
            IChangesHandler changesHandler)
        {
            _service = service;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvitationToTenderReadDto>> GetAll()
        {
            var invitations = _service.GetInvitations();
            return invitations == null ? (ActionResult<IEnumerable<InvitationToTenderReadDto>>)NoContent() : (ActionResult<IEnumerable<InvitationToTenderReadDto>>)Ok(invitations);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<InvitationToTenderReadDto> Get(Guid id)
        {
            var invitation = _service.GetOneInvitationToTender(id);
            return invitation == null ? (ActionResult<InvitationToTenderReadDto>)NotFound() : (ActionResult<InvitationToTenderReadDto>)Ok(invitation);
        }

        [HttpPost]
        public ActionResult<InvitationToTenderReadDto> Create(InvitationToTenderWriteDto request)
        {
            var currentUser = User.Identity!.Name;
            var created = _service.Create(request, currentUser!);
            return created == null ? (ActionResult<InvitationToTenderReadDto>)BadRequest() : (ActionResult<InvitationToTenderReadDto>)Ok(created);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<InvitationToTenderReadDto> Update(Guid id, [FromBody] InvitationToTenderUpdateDto request)
        {
            var invitation = _service.GetInvitationToTenderById(id);
            if (invitation == null)
                return NotFound();
            if (!string.IsNullOrEmpty(request.Reference))
            {
                var existed = _service.GetInvitationToTenderByReference(request.Reference);
                if (existed != null && existed.Id != id)
                    return BadRequest();
                invitation.Reference = request.Reference;
            }

            invitation.Year = request.Year ?? invitation.Year;
            invitation.ExecutionLocation = request.ExecutionLocation ?? invitation.ExecutionLocation;
            invitation.HasLaunched = request.HasLaunched ?? invitation.HasLaunched;
            invitation.Object = request.Object ?? invitation.Object;
            invitation.IsReservedForSme = request.IsReservedForSme ?? invitation.IsReservedForSme;
            invitation.OpenedOn = request.OpenedOn ?? invitation.OpenedOn;
            invitation.Trimester = request.Trimester ?? invitation.Trimester;
            invitation.DirectionId = request.DirectionId ?? invitation.DirectionId;
            invitation.Nature = request.Nature ?? invitation.Nature;
            invitation.UpdatedOn = DateTime.Now;
            var updated = _service.Update(invitation);
            return updated == null ? (ActionResult<InvitationToTenderReadDto>)BadRequest() : (ActionResult<InvitationToTenderReadDto>)Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<InvitationToTenderReadDto> Delete(Guid id)
        {
            var invitation = _service.GetInvitationToTenderById(id);
            if (invitation == null)
                return NotFound();
            _service.Delete(invitation);
            _changesHandler.Save();
            var deleted = _service.GetInvitationToTenderById(id);
            return deleted != null ? (ActionResult<InvitationToTenderReadDto>)BadRequest() : (ActionResult<InvitationToTenderReadDto>)Ok();
        }
    }
}
