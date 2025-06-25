using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.CreateSquashFieldActivityCommands
{
    public class CreateSquashFieldActivityCommandResponse: BaseResponse
    {
        public CreateSquashFieldActivityCommandResponse(): base()
        {            
        }
        public bool SavedRecords { get; set; }

    }
}
