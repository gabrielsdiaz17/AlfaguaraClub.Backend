using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands;
using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class BillingListVm
    {
        public long BillingId { get; set; }
        public DateTimeOffset BillingDate { get; set; }
        public string BillingConsecutive { get; set; }
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public int BillingStatusId { get; set; }
        public BillingStatusDto Status { get; set; }
        public long? BookingId { get; set; }
        public BookingDto Booking { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethodDto PaymentMethod { get; set; }
        public string Observations { get; set; }
        public List<BillingDetailDto> BillingDetail { get; set; }

    }
}
