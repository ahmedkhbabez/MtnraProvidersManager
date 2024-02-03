namespace MtnraProvidersManager_BAL.Dtos.Direction
{
    public class DirectionWriteDto
    {
        public string Abbreviation { get; set; } = string.Empty;
        public string ExtendedName { get; set; } = string.Empty;
        public Guid? InterlocutorId { get; set; }
    }
}
