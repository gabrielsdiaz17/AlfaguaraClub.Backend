using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.CreateStoryCommands
{
    public class CreateStoryCommand:IRequest<CreateStoryCommandResponse>
    {
        public string Title { get; set; }
        public int PriorityRating { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTimeOffset StoryPublishDate { get; set; }
        public long? SpaceActivityId { get; set; }
        public override string ToString()
        {
            return $"Story: Title{Title}; Priority Rating: {PriorityRating}; Summary: {Summary}";
        }
    }
}
