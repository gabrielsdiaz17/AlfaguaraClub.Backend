using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.QueryTaxCommands
{
    public class GetTaxQuery:IRequest<TaxListVm>
    {
        public int TaxId { get; set; }
    }
}
