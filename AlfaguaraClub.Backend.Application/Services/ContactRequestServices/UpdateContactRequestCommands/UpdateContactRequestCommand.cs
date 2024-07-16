using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.UpdateContactRequestCommands
{
    public class UpdateContactRequestCommand:IRequest
    {
        public long ContactRequestId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public long? SpaceId { get; set; }
        public Space Space { get; set; }
        public bool IsActive { get; set; }
    }
}
