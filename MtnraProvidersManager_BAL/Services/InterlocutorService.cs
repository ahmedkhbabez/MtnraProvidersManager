using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class InterlocutorService : IInterlocutorService
    {
        private readonly IRepository<Interlocutor> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public InterlocutorService(
            IRepository<Interlocutor> repository,
            IMapper mapper,
            IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }
        public InterlocutorReadDto Create(InterlocutorWriteDto interlocutor, string by)
        {
            var currentUser = _userService.GetUserByUsermane(by);
            var mappedInterlocutor = _mapper.Map<Interlocutor>(interlocutor);
            mappedInterlocutor.Creator = currentUser;
            mappedInterlocutor.AddedBy = currentUser!.Id;
            var createdInterlocutor = _repository.Create(mappedInterlocutor);
            return _mapper.Map<InterlocutorReadDto>(createdInterlocutor);
        }

        public void Delete(Interlocutor interlocutor)
            => _repository.Delete(interlocutor);

        public Interlocutor? GetInterlocutorById(Guid id)
            => _repository.GetOne(i => i.Id == id);

        public IEnumerable<InterlocutorReadDto> GetInterlocutors()
        {
            var interlocutors = _repository.GetAll();
            return _mapper.Map<IEnumerable<InterlocutorReadDto>>(interlocutors);
        }

        public InterlocutorReadDto? GetOneInterlocutor(Guid id)
        {
            var interlocutor = GetInterlocutorById(id);
            return _mapper.Map<InterlocutorReadDto>(interlocutor);
        }

        public InterlocutorReadDto Update(Interlocutor interlocutor)
        {
            _repository.Update(interlocutor);
            var updatedInterlocutor = GetInterlocutorById(interlocutor.Id);
            return _mapper.Map<InterlocutorReadDto>(updatedInterlocutor);
        }
    }
}
