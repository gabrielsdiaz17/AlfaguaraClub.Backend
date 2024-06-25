using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands
{
    public class PictureDto
    {
        public long PictureId { get; set; }
        public string PictureName { get; set; }
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public bool IsActive { get; set; }


    }
}
