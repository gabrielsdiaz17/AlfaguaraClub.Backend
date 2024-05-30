using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class GetBillingQuery: IRequest<BillingListVm>
    {
        public long BillingId { get; set; }
    }
}
