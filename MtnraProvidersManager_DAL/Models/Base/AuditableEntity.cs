using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models.Base
{
    public class AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public Guid? AddedBy { get; set; }

        [ForeignKey("AddedBy")]
        public virtual User? Creator { get; set; }

    }
}