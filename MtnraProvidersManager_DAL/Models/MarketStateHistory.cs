using MtnraProvidersManager_DAL.Enums;
using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models
{
    public class MarketStateHistory : AuditableEntity
    {
        [Required] public State State { get; set; }
        [Required] public DateTime Date { get; set; }

        public Guid? MarketId { get; set; }
        [ForeignKey("MarketId")] public virtual Market? Market { get; set; }
    }
}
