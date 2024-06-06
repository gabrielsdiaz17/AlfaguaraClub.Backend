using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.CreateStatusBookingCommands
{
    public class CreateStatusBookingCommand:IRequest<int>
    {
        public string Status { get; set; }
        public override string ToString()
        {
            return $"Status {Status} Created;";
        }
    }
}
