using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class AuditableEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public long UpdatedById { get; set; }
        public bool IsActive { get; set; }
    }
}
