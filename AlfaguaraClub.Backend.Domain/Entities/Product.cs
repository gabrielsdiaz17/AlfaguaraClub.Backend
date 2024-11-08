using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Product: AuditableEntity
    {
        public long ProductId { get; set; }
        [MaxLength(20)]
        public string ProductCode { get; set; }
        [MaxLength(200)]
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("Tax")]
        public int? TaxId { get; set; }
        public Tax Tax { get; set; }
        [ForeignKey("CostCenter")]
        public long? CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Picture> Pictures { get; set; }

    }
}
