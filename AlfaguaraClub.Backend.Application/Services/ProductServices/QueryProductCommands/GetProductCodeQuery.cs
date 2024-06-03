using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands
{
    public class GetProductCodeQuery: IRequest<ProductListVm>
    {
        public string Code { get; set; }
    }
}
