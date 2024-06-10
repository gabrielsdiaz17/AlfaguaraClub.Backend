using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands
{
    public class CreatePictureCommandResponse:BaseResponse
    {
        public CreatePictureCommandResponse():base()
        {
            
        }
        public long PictureId { get; set; }

    }
}
