using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.CreateTennisFieldActivityCommands
{
    public class CreateTennisFieldActivityCommandResponse: BaseResponse
    {
        public CreateTennisFieldActivityCommandResponse():base()
        {
            
        }
        public bool SavedRecords { get; set; }

    }
}
