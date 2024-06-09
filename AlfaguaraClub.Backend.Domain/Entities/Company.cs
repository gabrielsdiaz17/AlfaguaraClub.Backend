using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Company: AuditableEntity
    {
        [Key]
        public long CompanyId { get; set; }
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(20)]
        public string CompanyIdentifier { get; set; }

        [ForeignKey("IdentificationType")]
        public int IdentificationTypeId { get; set; }
        public IdentificationType IdentificationType { get; set; }
        [Column(TypeName = "text")]
        public string CompanyLogo { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
