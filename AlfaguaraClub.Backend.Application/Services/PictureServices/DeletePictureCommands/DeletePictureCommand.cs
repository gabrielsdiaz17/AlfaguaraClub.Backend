using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.DeletePictureCommands
{
    public class DeletePictureCommand : IRequest
    {
        public long PictureId { get; set; }
    }
}
