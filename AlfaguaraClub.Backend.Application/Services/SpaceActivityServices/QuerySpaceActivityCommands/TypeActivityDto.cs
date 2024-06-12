using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class TypeActivityDto
    {
        public int TypeActivityId { get; set; }
        public string TypeActivityName { get; set; }
        public bool IsActive { get; set; }
    }
}
