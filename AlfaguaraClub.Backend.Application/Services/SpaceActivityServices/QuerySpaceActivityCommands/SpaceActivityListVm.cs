using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class SpaceActivityListVm
    {
        public long SpaceActivityId { get; set; }
        public string ActivityName { get; set; }

        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }
        public int? TypeActivityId { get; set; }
        public TypeActivityDto TypeActivity { get; set; }
        public long SpaceId { get; set; }
        public SpaceDto Space { get; set; }
        public DateTimeOffset ActivityDate { get; set; }
        public TimeSpan StartActivityHour { get; set; }
        public TimeSpan EndActivityHour { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BookingDto> Bookings { get; set; }

    }
}
