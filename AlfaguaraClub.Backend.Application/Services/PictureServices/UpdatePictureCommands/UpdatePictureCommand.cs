﻿using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.UpdatePictureCommands
{
    public class UpdatePictureCommand:IRequest
    {
        public long PictureId { get; set; }
        public string PictureName { get; set; }
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public long? SpaceId { get; set; }
        public long? ProductId { get; set; }
        public bool IsActive { get; set; }

    }
}
