using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.UpdateStoryCommands
{
    public class UpdateStoryCommand:IRequest
    {
        public long StoryId { get; set; }
        public string Title { get; set; }
        public int PriorityRating { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public long? SpaceActivityId { get; set; }
    }
}
