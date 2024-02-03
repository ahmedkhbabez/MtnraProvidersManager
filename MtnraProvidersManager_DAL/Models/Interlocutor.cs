using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MtnraProvidersManager_DAL.Models
{
    public class Interlocutor : AuditableEntity
    {
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string LastName { get; set; } = string.Empty;
    }
}
