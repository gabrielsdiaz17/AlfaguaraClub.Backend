using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.UpdateSpaceActivityCommands
{
    public class UpdateSpaceActivityCommand : IRequest
    {
        public long SpaceActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }
        public int? TypeActivityId { get; set; }
        public long SpaceId { get; set; }
        public TimeSpan StartActivityHour { get; set; }
        public TimeSpan EndActivityHour { get; set; }
        public TimeSpan ActivityHour { get; set; }
    }
}
