using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Space: AuditableEntity
    {
        [Key]
        public long SpaceId { get; set; }
        [MaxLength(200)]
        public string SpaceName { get; set; }
        [Column(TypeName = "text")]
        public string SpaceDescription { get; set; }

        [ForeignKey("CostCenter")]
        public long CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }
        [Column(TypeName = "text")]
        public string? VideoLink { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<SpaceActivity> SpaceActivities { get; set; }
    }
}
