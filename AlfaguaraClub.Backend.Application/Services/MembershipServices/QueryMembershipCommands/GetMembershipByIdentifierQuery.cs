using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands
{
    public class GetMembershipByIdentifierQuery:IRequest<MembershipListVm>
    {
        public string Identifier { get; set; }
    }
}
