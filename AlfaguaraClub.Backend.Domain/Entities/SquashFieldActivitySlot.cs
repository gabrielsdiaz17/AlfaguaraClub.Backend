using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class SquashFieldActivitySlot: AuditableEntity
    {
        [Key]
        public long SquashFieldActivitySlotId { get; set; }
        [ForeignKey("SpaceActivity")]
        public long SpaceActivityId { get; set; }
        public SpaceActivity SpaceActivity { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
