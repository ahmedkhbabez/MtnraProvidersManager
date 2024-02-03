using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{

    public class DirectionService : IDirectionService
    {
        private readonly IRepository<Direction> _repository;
        private readonly IRepository<Interlocutor> _interlocutorRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DirectionService(
            IRepository<Direction> repository,
            IRepository<Interlocutor> interlocutorRepository,
            IMapper mapper,
            IUserService userService)
        {
            _repository = repository;
            _interlocutorRepository = interlocutorRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public DirectionReadDto Create(DirectionWriteDto direction, string by)
        {
            var mappedDirection = _mapper.Map<Direction>(direction);
            var currentUser = _userService.GetUserByUsermane(by);
            mappedDirection.Creator = currentUser;
            mappedDirection.AddedBy = currentUser!.Id;
            var createdDirection = _repository.Create(mappedDirection);
            var result = _mapper.Map<DirectionReadDto>(createdDirection);
            result.Interlocutor = GetMappedInterlocutor(result.Interlocutor!.Id);
            return result;
        }

        public void Delete(Direction direction) => _repository.Delete(direction);

        public Direction? GetDirectionById(Guid id)
            => _repository.GetOne(dir => dir.Id == id);

        public IEnumerable<DirectionReadDto> GetDirections()
        {
            var directions = _repository.GetAll();
            var mappedDirections = _mapper.Map<IEnumerable<DirectionReadDto>>(directions);
            List<DirectionReadDto> directionReadDtos = mappedDirections.ToList();
            foreach (var dir in directionReadDtos)
                dir.Interlocutor = GetMappedInterlocutor(dir.Interlocutor!.Id);
            return directionReadDtos;
        }

        private InterlocutorReadDto GetMappedInterlocutor(Guid interlocutorId)
        {
            var interlocutor = _interlocutorRepository.GetOne(inter => inter.Id == interlocutorId);
            return _mapper.Map<InterlocutorReadDto>(interlocutor);
        }

        public DirectionReadDto? GetOneDirection(Guid id)
        {
            var direction = _repository.GetOne(dir => dir.Id == id);
            if (direction == null)
                return null;
            var mappedDirection = _mapper.Map<DirectionReadDto>(direction);
            mappedDirection.Interlocutor = GetMappedInterlocutor(mappedDirection.Interlocutor!.Id);
            return mappedDirection;
        }

        public DirectionReadDto Update(Direction direction)
        {
            _repository.Update(direction);
            var updatedDirection = GetDirectionById(direction.Id);
            var result = _mapper.Map<DirectionReadDto>(updatedDirection);
            result.Interlocutor = GetMappedInterlocutor(result.Interlocutor!.Id);
            return result;
        }
    }

}