using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands
{
    public class CreateCostCenterCommandResponse:BaseResponse
    {
        public CreateCostCenterCommandResponse():base()
        {
            
        }
        public long CostCenterId { get; set; }

    }
}
