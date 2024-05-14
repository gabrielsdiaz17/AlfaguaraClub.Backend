using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Company: AuditableEntity
    {
        [Key]
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIdentifier { get; set; }
        public int IdentificationTypeId { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string CompanyLogo { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
