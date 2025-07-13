using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class MonthlyCouponBook : AuditableEntity
    {
        [Key]
        public long MonthlyCouponBookId { get; set; }

        [ForeignKey("Membership")]
        public long MembershipId { get; set; }
        public Membership Membership { get; set; }

        public DateTime Month { get; set; } 
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }

        public ICollection<CouponPurchase> Purchases { get; set; }
    }
}
