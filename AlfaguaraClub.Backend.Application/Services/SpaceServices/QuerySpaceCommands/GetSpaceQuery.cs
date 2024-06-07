﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands
{
    public class GetSpaceQuery:IRequest<SpaceListVm>
    {
        public long SpaceId { get; set; }
    }
}
