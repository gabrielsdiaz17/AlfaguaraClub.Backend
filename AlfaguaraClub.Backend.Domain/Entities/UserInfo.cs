using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class UserInfo: AuditableEntity
    {
        [Key]
        public long UserInfoId { get; set; }
        [Column(TypeName = "mediumtext")]
        public string UserData { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RecordDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoged { get; set; }

    }
}
