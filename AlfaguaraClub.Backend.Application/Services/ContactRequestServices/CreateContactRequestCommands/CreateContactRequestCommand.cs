using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands
{
    public class CreateContactRequestCommand:IRequest<CreateContactRequestCommandResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public StatusRequest StatusRequest { get; set; }
        [ForeignKey("SpaceId")]
        public long? SpaceId { get; set; }
        public DateTime DateRequest { get; set; }
        public bool IsActive { get; set; }
    }
}
