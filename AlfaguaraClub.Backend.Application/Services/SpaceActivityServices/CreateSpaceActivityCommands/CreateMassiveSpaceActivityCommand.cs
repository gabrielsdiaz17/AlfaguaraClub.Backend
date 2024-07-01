using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateMassiveSpaceActivityCommand:IRequest<CreateMassiveSpaceActivityCommandResponse>
    {
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }
        public int? TypeActivityId { get; set; }
        public ActivityVisibility Visibility { get; set; }
        public long SpaceId { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public TimeSpan StartActivityHour { get; set; }
        public TimeSpan EndActivityHour { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Space Activity: {ActivityName}; Description: {ActivityDescription}; Quorum: {AvailableQuorum}; Space:{SpaceId}";
        }
    }
}
