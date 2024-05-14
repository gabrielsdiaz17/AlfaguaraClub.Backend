using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class TypeActivity:AuditableEntity
    {
        public int TypeActivityId { get; set; }
        public string TypeActivityName { get; set; }
    }
}
