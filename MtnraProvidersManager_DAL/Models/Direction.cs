using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models
{
    public class Direction : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        [MinLength(1)]
        public string Abbreviation { get; set; } = string.Empty;

        [StringLength(100)]
        public string ExtendedName { get; set; } = string.Empty;
        public Guid? InterlocutorId { get; set; }

        [ForeignKey("InterlocutorId")]
        public virtual Interlocutor? Interlocutor { get; set; }
    }
}
