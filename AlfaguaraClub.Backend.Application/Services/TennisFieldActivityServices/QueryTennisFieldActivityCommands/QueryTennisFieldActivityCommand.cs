﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.QueryTennisFieldActivityCommands
{
    public class QueryTennisFieldActivityCommand: IRequest<List<TennisFieldActivitySlotVm>>
    {
        public long SpaceActivityId { get; set; }

    }
}
