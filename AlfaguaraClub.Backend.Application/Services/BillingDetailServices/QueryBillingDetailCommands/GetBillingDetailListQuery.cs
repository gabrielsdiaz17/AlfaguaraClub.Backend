using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands
{
    public class GetBillingDetailListQuery:IRequest<List<BillingDetailListVm>>
    {
        public long BillingId { get; set; }
    }
}
