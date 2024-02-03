namespace MtnraProvidersManager_BAL.Dtos.User
{
    public class UserReadDto
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
