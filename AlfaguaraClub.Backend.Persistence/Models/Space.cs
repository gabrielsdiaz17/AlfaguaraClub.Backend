using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Space
    {
        [Key]
        public long SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string SpaceDescription { get; set; }

        [ForeignKey("CostCenter")]
        public long CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }
        public string? VideoLink { get; set; }

    }
}
