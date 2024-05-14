using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class IdentificationType: AuditableEntity
    {
        public int IdendificationTypeId { get; set; }
        public int IdentificationTypeCode { get; set; }
        public string  Nomenclature { get; set; }
        public string Description { get; set; }

        private ICollection<User> Users;
    }
}
