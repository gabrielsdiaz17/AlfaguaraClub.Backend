using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class CouponPurchase : AuditableEntity
    {
        [Key]
        public long CouponPurchaseId { get; set; }

        [ForeignKey("MonthlyCouponBook")]
        public long MonthlyCouponBookId { get; set; }
        public MonthlyCouponBook MonthlyCouponBook { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        [ForeignKey("CostCenter")]
        public long? CostCenterId { get; set; } 
        public CostCenter? CostCenter { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; } 
        public User? User { get; set; }
    }
}
