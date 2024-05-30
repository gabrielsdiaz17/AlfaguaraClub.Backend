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
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public long? BookingId { get; set; }
        public BookingDto? Booking { get; set; }
        public string Concept { get; set; }
        public decimal Subtotal { get; set; }
        public double? PercentageTaxes { get; set; }
        public decimal? TaxesValue { get; set; }
        public decimal TotalPayment { get; set; }
        public int BillingStatusId { get; set; }
        public BillingStatusDto BillingStatus { get; set; }

    }
}
