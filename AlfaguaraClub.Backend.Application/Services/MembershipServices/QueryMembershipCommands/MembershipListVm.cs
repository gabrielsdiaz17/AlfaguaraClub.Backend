using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands
{
    public class MembershipListVm
    {
        public long MembershipId { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserDto> Users { get; set; }

    }
}
