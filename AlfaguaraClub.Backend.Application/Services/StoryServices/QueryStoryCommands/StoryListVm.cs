using AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.QueryStoryCommands
{
    public class StoryListVm
    {
        public long StoryId { get; set; }
        public string Title { get; set; }
        public int PriorityRating { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public DateTimeOffset StoryPublishDate { get; set; }
        public long? SpaceActivityId { get; set; }
        public SpaceActivityDto Activity { get; set; }
        public ICollection<PictureDto> Pictures { get; set; }


    }
}
