﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands
{
    public class GetCostCenterQuery:IRequest<CostCenterListVm>
    {
        public long CostCenterId { get; set; }
    }
}
