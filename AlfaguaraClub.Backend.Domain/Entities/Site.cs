using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Site: AuditableEntity
    {
        [Key]
        public long SiteId { get; set; }
        [MaxLength(200)]
        public string SiteName { get; set; }
        [MaxLength(500)]
        public string SiteAddress { get; set; }
        [Column(TypeName = "text")]
        public string? SiteLocationMap { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CostCenter> CostCenters { get; set; }
    }
}
