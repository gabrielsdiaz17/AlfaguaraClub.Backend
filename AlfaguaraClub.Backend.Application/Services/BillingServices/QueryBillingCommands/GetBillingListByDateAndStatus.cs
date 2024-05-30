using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class GetBillingListByDateAndStatus: IRequest<List<BillingListVm>>
    {
        public DateTimeOffset Date { get; set; }
        public int BillingStatusId { get; set; }
    }
}
