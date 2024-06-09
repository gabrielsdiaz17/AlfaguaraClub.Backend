using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
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
        public bool IsActive { get; set; }

        private ICollection<User> Users;
    }
}
