﻿using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands
{
    public class SpaceActivityDto
    {
        public long SpaceActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }
        public int? TypeActivityId { get; set; }
        public ActivityVisibility Visibility { get; set; }
        public TimeSpan StartActivityHour { get; set; }
        public TimeSpan EndActivityHour { get; set; }
        public TimeSpan ActivityHour { get; set; }
        public bool IsActive { get; set; }


    }
}
