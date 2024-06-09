using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class BillingDetail: AuditableEntity
    {
        public long BillingDetailId { get; set; }
        public long BillingId { get; set; }
        public Billing Billing { get; set; }    
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        [MaxLength(500)]
        public decimal SubtotalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsActive { get; set; }

    }
}
