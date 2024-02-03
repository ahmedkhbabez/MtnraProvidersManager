using MtnraProvidersManager_DAL.Enums;
using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models
{
    public class Market : TabEntity
    {
        [Required, MinLength(1)] public string Object { get; set; } = string.Empty;
        [Required] public State State { get; set; }
        [Required] public double Estimation { get; set; }
        [Required] public DateTime LaunchedAt { get; set; }
        [Required] public DateTime ProvisionalReception { get; set; }
        [Required] public DateTime DefinitiveReception { get; set; }
        [Required] public DateTime WarrantyDeadline { get; set; }
        [Required] public MarketNature Nature { get; set; }

        public Guid? CompanyId { get; set; }
        [ForeignKey("CompanyId")] public virtual Company? Company { get; set; }

        public Guid? OriginalInvitationToTenderId { get; set; }
        [ForeignKey("OriginalInvitationToTenderId")] public virtual InvitationToTender? OriginalInvitationToTender { get; set; }

        public virtual ICollection<MarketStateHistory>? StatesHistory { get; set; }
    }
}
