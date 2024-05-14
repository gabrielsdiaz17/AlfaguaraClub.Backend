using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class SpaceActivity: AuditableEntity
    {

        [Key]
        public long SpaceActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }

        public int? TypeActivityId { get; set; }
        public TypeActivity TypeActivity { get; set; }

        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        public Space Space { get; set; }
        public DateTimeOffset ActivityDate { get; set; }
        public TimeSpan ActivityHour { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
