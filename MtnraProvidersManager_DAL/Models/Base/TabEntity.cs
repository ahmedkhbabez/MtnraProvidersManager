using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models.Base
{
    public class TabEntity : AuditableEntity
    {
        [Required] public uint Year { get; set; }
        [Required, MinLength(2)] public string Reference { get; set; } = string.Empty;

        public Guid DirectionId { get; set; }
        [ForeignKey("DirectionId")] public virtual Direction? Direction { get; set; }
    }
}
