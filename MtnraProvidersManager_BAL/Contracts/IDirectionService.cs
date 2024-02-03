using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IDirectionService
    {
        IEnumerable<DirectionReadDto> GetDirections();
        Direction? GetDirectionById(Guid id);
        DirectionReadDto? GetOneDirection(Guid id);
        DirectionReadDto Update(Direction direction);
        DirectionReadDto Create(DirectionWriteDto direction, string by);
        void Delete(Direction direction);
    }
}
