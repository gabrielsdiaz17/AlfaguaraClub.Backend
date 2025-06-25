using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class TennisFieldActivitySlot: AuditableEntity
    {
        [Key]
        public long TennisFieldActivitySlotId { get; set; }
        [ForeignKey("SpaceActivity")]
        public long SpaceActivityId { get; set; }
        public SpaceActivity SpaceActivity { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
