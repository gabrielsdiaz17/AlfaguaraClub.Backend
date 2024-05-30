using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class BillingDto
    {
        public long BillingId { get; set; }
        public DateTimeOffset BillingDate { get; set; }
        public long UserId { get; set; }
        public long? BookingId { get; set; }
        public string BillingConsecutive { get; set; }
        public decimal Subtotal { get; set; }
        public double? PercentageTaxes { get; set; }
        public decimal? TaxesValue { get; set; }
        public decimal TotalPayment { get; set; }
        public int BillingStatusId { get; set; }
    }
}
