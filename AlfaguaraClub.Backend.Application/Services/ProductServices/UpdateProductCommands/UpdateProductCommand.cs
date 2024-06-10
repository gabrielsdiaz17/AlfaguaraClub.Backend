using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.UpdateProductCommands
{
    public class UpdateProductCommand: IRequest
    {
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int TaxId { get; set; }
        public bool IsActive { get; set; }

    }
}
