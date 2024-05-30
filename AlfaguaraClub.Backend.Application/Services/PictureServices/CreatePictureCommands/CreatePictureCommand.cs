using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands
{
    public class CreatePictureCommand:IRequest<long>
    {
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public long? SpaceId { get; set; }

    }
}
