using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class BillingDetailDto
    {
        public long BillingDetailId { get; set; }
        public long BillingId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
