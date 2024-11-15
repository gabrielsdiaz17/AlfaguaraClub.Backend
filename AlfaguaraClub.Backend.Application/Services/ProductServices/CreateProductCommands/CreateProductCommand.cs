using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands
{
    public class CreateProductCommand: IRequest<CreateProductCommandResponse>
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int? TaxId { get; set; }
        public long? CostCenterId { get; set; }
        public bool IsActive { get; set; }
        public override string ToString()
        {
            return $"Product Code: {ProductCode}; Description: {ProductDescription}; Unit Price: {UnitPrice}";
        }
    }
}
