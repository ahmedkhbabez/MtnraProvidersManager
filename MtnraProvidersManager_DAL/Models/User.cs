using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MtnraProvidersManager_DAL.Models
{
    public class User : AuditableEntity
    {
        [Required, StringLength(50)] public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(50)] public string LastName { get; set; } = string.Empty;
        [Required] public string Role { get; set; } = "Moderator";
        [Required, StringLength(20)] public string Username { get; set; } = string.Empty;
        [Required] public string HashedPassword { get; set; } = string.Empty;

    }
}
