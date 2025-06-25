using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.QuerySlotCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.QuerySquashFieldActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.QueryTennisFieldActivityCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class BookingListVm
    {
        public long BookingId { get; set; }
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public long SpaceActivityId { get; set; }
        public SpaceActivityDto SpaceActivity { get; set; }
        public long? MembershipId { get; set; }
        public MembershipDto Membership { get; set; }
        public int StatusBookingId { get; set; }
        public StatusBookingDto StatusBooking { get; set; }
        public long? SpaceActivitySlotId { get; set; }
        public SpaceActivitySlotVm SpaceActivitySlot { get; set; }
        public long? TennisFieldActivitySlotId { get; set; }
        public TennisFieldActivitySlotVm TennisFieldActivitySlot { get; set; }
        public long? SquashFieldActivitySlotId { get; set; }
        public SquashFieldActivitySlotVm SquashFieldActivitySlot { get; set; }
        public bool IsActive { get; set; }
        public BillingDto Billing { get; set; }
    }
}
