using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands
{
    public class CreatePictureCommand:IRequest<CreatePictureCommandResponse>
    {
        public string PictureName { get; set; }
        public IFormFile PictureFile { get; set; }
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public long? SpaceId { get; set; }
        public long? ProductId { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Picture Created";
        }
    }
}
