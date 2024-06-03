using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands
{
    public class CreateProductCommand: IRequest<long>
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int TaxId { get; set; }

    }
}
