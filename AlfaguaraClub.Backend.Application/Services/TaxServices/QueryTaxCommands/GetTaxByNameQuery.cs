using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.QueryTaxCommands
{
    public class GetTaxByNameQuery: IRequest<TaxListVm>
    {
        public string TaxName { get; set; }
    }
}
