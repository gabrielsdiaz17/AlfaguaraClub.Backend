using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class IdentificationType: AuditableEntity
    {
        [Key]
        public int IdendificationTypeId { get; set; }
        public int IdentificationTypeCode { get; set; }
        [MaxLength(20)]
        public string  Nomenclature { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        private ICollection<User> Users;
    }
}
