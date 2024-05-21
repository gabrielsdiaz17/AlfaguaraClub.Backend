using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Parameter: AuditableEntity
    {
        public long ParameterId { get; set; }
        [MaxLength(500)]
        public string ParameterName { get; set; }
        [Column(TypeName = "text")]
        public string ParameterValue { get; set; }
    }
}
