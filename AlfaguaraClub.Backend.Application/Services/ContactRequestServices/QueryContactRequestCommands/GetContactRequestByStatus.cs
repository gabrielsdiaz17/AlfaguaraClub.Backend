using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands
{
    public class GetContactRequestByStatus:IRequest<List<ContactRequestListVm>>
    {
        public StatusRequest Status { get; set; }
    }
}
