using MtnraProvidersManager_BAL.Dtos.Interlocutor;

namespace MtnraProvidersManager_BAL.Dtos.Direction
{
    public class DirectionReadDto
    {
        public Guid Id { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
        public string ExtendedName { get; set; } = string.Empty;
        public InterlocutorReadDto? Interlocutor { get; set; }
    }
}
