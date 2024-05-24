using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands
{
    public class CreateMembershipCommand: IRequest<long>
    {
        public string UniqueIdentifier { get; set; }
    }
}
