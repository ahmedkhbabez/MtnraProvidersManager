using MtnraProvidersManager_BAL.Dtos.Interlocutor;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IInterlocutorService
    {
        IEnumerable<InterlocutorReadDto> GetInterlocutors();
        Interlocutor? GetInterlocutorById(Guid id);
        InterlocutorReadDto? GetOneInterlocutor(Guid id);
        InterlocutorReadDto Update(Interlocutor interlocutor);
        InterlocutorReadDto Create(InterlocutorWriteDto interlocutor, string by);
        void Delete(Interlocutor interlocutor);
    }
}
