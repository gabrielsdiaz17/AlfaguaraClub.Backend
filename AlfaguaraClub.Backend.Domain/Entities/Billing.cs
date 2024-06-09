using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaguaraClub.Backend.Domain.Enums;
using AlfaguaraClub.Backend.Domain.Entities;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Billing: AuditableEntity
    {
        [Key]
        public long BillingId { get; set; }
        public DateTimeOffset BillingDate { get; set; }
        [MaxLength(50)]
        public string BillingConsecutive { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public int BillingStatusId { get; set; }
        public BillingStatus Status { get; set; }

        [ForeignKey("Booking")]
        public long? BookingId { get; set; }
        public Booking Booking { get; set; }
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [MaxLength(500)]
        public string Observations { get; set; }
        public bool IsActive { get; set; }
        public List<BillingDetail> BillingDetail { get; set; }
    }
}
