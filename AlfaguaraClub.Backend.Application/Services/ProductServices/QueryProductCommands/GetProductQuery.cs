using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands
{
    public class GetProductQuery:IRequest<ProductListVm>
    {
        public long ProductId { get; set; }
    }
}
