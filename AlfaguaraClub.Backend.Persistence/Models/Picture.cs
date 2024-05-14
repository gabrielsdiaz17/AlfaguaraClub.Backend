﻿using AlfaguaraClub.Backend.Persistence.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Picture: AuditableEntity
    {
        [Key]
        public long PictureId { get; set; }
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public Story Story { get; set; }
        public long? SpaceId { get; set; }
        public Space Space { get; set; }
    }
}
