using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.CreateStoryCommands
{
    public class CreateStoryCommandResponse:BaseResponse
    {
        public CreateStoryCommandResponse():base()
        {
            
        }
        public long StoryId { get; set; }
    }
}
