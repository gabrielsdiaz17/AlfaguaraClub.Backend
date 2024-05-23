using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands
{
    public class SpaceDto
    {
        public long SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string SpaceDescription { get; set; }
        public string? VideoLink { get; set; }
    }
}
