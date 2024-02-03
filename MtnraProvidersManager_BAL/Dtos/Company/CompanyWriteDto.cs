namespace MtnraProvidersManager_BAL.Dtos.Company
{
    public class CompanyWriteDto
    {
        public string Name { get; set; } = string.Empty;
        public string FieldOfActivity { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsSme { get; set; }
    }
}
