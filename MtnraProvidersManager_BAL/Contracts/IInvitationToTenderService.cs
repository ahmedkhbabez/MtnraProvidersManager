using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IInvitationToTenderService
    {
        IEnumerable<InvitationToTenderReadDto> GetInvitations();
        InvitationToTender? GetInvitationToTenderById(Guid id);
        InvitationToTenderReadDto? GetOneInvitationToTender(Guid id);
        InvitationToTenderReadDto? GetInvitationToTenderByReference(string reference);
        InvitationToTenderReadDto Update(InvitationToTender invitation);
        InvitationToTenderReadDto Create(InvitationToTenderWriteDto invitation, string by);
        void Delete(InvitationToTender invitation);
    }
}
