using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands
{
    public class UpdateSpaceCommand:IRequest
    {
        public long SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string SpaceDescription { get; set; }
        public long CostCenterId { get; set; }
        public string? VideoLink { get; set; }
        public bool IsActive { get; set; }

    }
}
