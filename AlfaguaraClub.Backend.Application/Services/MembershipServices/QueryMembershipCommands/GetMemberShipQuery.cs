using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands
{
    public class GetMemberShipQuery:IRequest<MembershipListVm>
    {
        public long MembershipId { get; set; }
    }
}
