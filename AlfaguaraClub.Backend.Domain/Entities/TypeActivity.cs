using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class TypeActivity:AuditableEntity
    {
        public int TypeActivityId { get; set; }
        [MaxLength(100)]
        public string TypeActivityName { get; set; }
    }
}
