using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands
{
    public class BillingDetailListVm
    {
        public long BillingDetailId { get; set; }
        public long BillingId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
