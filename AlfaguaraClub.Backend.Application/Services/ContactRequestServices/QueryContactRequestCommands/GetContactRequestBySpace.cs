using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands
{
    public class GetContactRequestBySpace: IRequest<List<ContactRequestListVm>>
    {
        public long SpaceId { get; set; }
    }
}
