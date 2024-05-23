using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands
{
    public class CreateCostCenterCommand: IRequest<long>        
    {
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public long SiteId { get; set; }

    }
}
