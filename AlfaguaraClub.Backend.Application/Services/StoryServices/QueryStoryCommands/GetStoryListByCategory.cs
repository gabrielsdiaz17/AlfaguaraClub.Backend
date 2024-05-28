using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.QueryStoryCommands
{
    public class GetStoryListByCategory: IRequest<List<StoryListVm>>
    {
        public int CategoryId { get; set; }
    }
}
