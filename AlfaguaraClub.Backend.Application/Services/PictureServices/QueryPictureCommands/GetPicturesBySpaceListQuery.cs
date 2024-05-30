using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.QueryPictureCommands
{
    public class GetPicturesBySpaceListQuery:IRequest<List<PictureListVm>>
    {
        public long SpaceId { get; set; }
    }
}
