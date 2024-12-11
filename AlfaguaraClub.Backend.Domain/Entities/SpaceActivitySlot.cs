using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class SpaceActivitySlot: AuditableEntity
    {
        [Key]
        public long SpaceActivitySlotId { get; set; }

        [ForeignKey("SpaceActivity")]
        public long SpaceActivityId { get; set; }
        public SpaceActivity SpaceActivity { get; set; }

        public int RailNumber { get; set; } 
        public int MaxQuorum { get; set; } 
        public int CurrentQuorum { get; set; } 

        public bool IsAvailable => CurrentQuorum < MaxQuorum;
        public bool IsActive { get; set; }
    }
}
