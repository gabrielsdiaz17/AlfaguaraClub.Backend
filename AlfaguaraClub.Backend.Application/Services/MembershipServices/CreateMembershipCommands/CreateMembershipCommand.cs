using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands
{
    public class CreateMembershipCommand: IRequest<CreateMembershipCommandResponse>
    {
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Membership Unique Identifier: {UniqueIdentifier}";
        }
    }
}
