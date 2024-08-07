﻿using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.QueryPictureCommands
{
    public class PictureListVm
    {
        public long PictureId { get; set; }
        public string PictureName { get; set; }
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public StoryDto Story { get; set; }
        public long? SpaceId { get; set; }
        public SpaceDto Space { get; set; }
        public long? ProductId { get; set; }
        public ProductDto Product { get; set; }
        public bool IsActive { get; set; }

    }
}
