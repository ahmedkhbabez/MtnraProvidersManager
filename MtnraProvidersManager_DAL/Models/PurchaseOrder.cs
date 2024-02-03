using MtnraProvidersManager_DAL.Enums;
using MtnraProvidersManager_DAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtnraProvidersManager_DAL.Models
{
    public class PurchaseOrder : TabEntity
    {
        [Required] public State? State { get; set; }
        [Required] public double Amount { get; set; }

        public Guid? CompanyId { get; set; }
        [ForeignKey("CompanyId")] public virtual Company? Company { get; set; }
    }
}