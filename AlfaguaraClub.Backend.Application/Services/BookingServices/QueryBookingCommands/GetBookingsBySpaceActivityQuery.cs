using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class GetBookingsBySpaceActivityQuery: IRequest<List<BookingListVm>>
    {
        public long SpaceActivityId { get; set; }
    }
}
