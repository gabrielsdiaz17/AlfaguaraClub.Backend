using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class BillingStatus: AuditableEntity
    {
        public int BillingStatusId { get; set; }
        [MaxLength(100)]
        public string Status { get; set; }
        [MaxLength(20)]
        public string? Nomenclature { get; set; }
    }
}
