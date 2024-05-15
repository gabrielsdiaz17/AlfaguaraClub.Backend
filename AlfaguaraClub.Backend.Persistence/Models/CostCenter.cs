using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class CostCenter: AuditableEntity
    {
        [Key]
        public long CostCenterId { get; set; }
        [MaxLength(20)]
        public string CostCenterCode { get; set; }
        [MaxLength(200)]
        public string CostCenterName { get; set; }
        [ForeignKey("Site")]
        public long SiteId { get; set; }
        public Site Site { get; set; }
        public ICollection<Space> Spaces { get; set; }
    }
}
