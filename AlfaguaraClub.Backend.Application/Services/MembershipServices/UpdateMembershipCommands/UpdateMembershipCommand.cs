﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.UpdateMembershipCommands
{
    public class UpdateMembershipCommand:IRequest
    {
        public long MembershipId { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }

    }
}
