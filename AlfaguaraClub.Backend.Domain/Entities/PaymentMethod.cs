using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class PaymentMethod: AuditableEntity
    {
        public  int PaymentMethodId { get; set; }
        [MaxLength(50)]
        public string PaymentMethodCode { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
