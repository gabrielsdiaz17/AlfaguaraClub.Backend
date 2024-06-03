using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands
{
    public class ProductListVm
    {
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int TaxId { get; set; }
        public TaxDto Tax { get; set; }
    }
}
