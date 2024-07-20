using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands
{
    public class ContactRequestListVm
    {
        public long ContactRequestId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string? ObservationResponse { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public long? SpaceId { get; set; }
        public SpaceDto Space { get; set; }
        public DateTime DateRequest { get; set; }
        public bool IsActive { get; set; }
    }
}
