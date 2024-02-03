using MtnraProvidersManager_DAL.Enums;
using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MtnraProvidersManager_DAL.Models
{
    public class InvitationToTender : TabEntity
    {
        [Required, MinLength(1)] public string Object { get; set; } = string.Empty;
        [Required] public bool HasLaunched { get; set; }
        [Required] public bool IsReservedForSme { get; set; }
        [Required] public Trimester Trimester { get; set; }
        [Required] public MarketNature Nature { get; set; }
        [Required, MinLength(5)] public string ExecutionLocation { get; set; } = string.Empty;
        [Required] public DateTime OpenedOn { get; set; }
    }
}
