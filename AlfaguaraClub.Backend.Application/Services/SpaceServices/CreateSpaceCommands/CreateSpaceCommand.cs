using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands
{
    public class CreateSpaceCommand:IRequest<long>
    {
        public string SpaceName { get; set; }
        public string SpaceDescription { get; set; }
        public long CostCenterId { get; set; }
        public string? VideoLink { get; set; }
        public override string ToString()
        {
            return $"Space Name {SpaceName}; Description: {SpaceDescription}; Cost Center: {CostCenterId}";
        }
    }
}
