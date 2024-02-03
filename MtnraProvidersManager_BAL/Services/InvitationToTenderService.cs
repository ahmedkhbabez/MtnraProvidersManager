using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class InvitationToTenderService : IInvitationToTenderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InvitationToTender> _repository;
        private readonly IDirectionService _directionService;
        private readonly IUserService _userService;

        public InvitationToTenderService(
            IRepository<InvitationToTender> repository,
            IDirectionService directionService,
            IMapper mapper,
            IUserService userService)
        {
            _repository = repository;
            _directionService = directionService;
            _mapper = mapper;
            this._userService = userService;
        }

        public InvitationToTenderReadDto Create(InvitationToTenderWriteDto invitation, string by)
        {
            var currentUser = _userService.GetUserByUsermane(by);
            var mapped = _mapper.Map<InvitationToTender>(invitation);
            mapped.AddedBy = currentUser!.Id;
            mapped.Creator = currentUser;
            var created = _repository.Create(mapped);
            var result = _mapper.Map<InvitationToTenderReadDto>(created);
            result.Direction = _directionService.GetOneDirection(result.Direction!.Id);
            return result;
        }

        public void Delete(InvitationToTender invitation) => _repository.Delete(invitation);

        public InvitationToTender? GetInvitationToTenderById(Guid id)
            => _repository.GetOne(inv => inv.Id == id);

        public IEnumerable<InvitationToTenderReadDto> GetInvitations()
        {
            var invitations = _repository.GetAll();
            var mapped = _mapper.Map<IEnumerable<InvitationToTenderReadDto>>(invitations);
            foreach (var inv in mapped)
                inv.Direction = _directionService.GetOneDirection(inv.Direction!.Id);
            return mapped;
        }

        public InvitationToTenderReadDto? GetOneInvitationToTender(Guid id)
        {
            var mapped = _mapper.Map<InvitationToTenderReadDto>(_repository.GetOne(inv => inv.Id == id));
            mapped.Direction = _directionService.GetOneDirection(mapped.Direction!.Id);
            return mapped;
        }

        public InvitationToTenderReadDto Update(InvitationToTender invitation)
        {
            _repository.Update(invitation);
            return GetOneInvitationToTender(invitation.Id)!;
        }

        public InvitationToTenderReadDto? GetInvitationToTenderByReference(string reference)
        {
            var invitationToTender = _repository.GetOne(m => m.Reference == reference);
            return invitationToTender == null ? null : _mapper.Map<InvitationToTenderReadDto>(invitationToTender);
        }
    }
}
