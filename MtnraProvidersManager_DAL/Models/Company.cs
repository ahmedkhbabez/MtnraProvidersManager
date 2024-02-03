using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MtnraProvidersManager_DAL.Models
{
    public class Company : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string FieldOfActivity { get; set; } = string.Empty;

        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        public bool IsSme { get; set; }
    }
}
