using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateCouponPurchaseCommands
{
    public class ProductPurchaseDto
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public long? CostCenterId { get; set; } 
        public string? Comment { get; set; }    
        public long? UserId { get; set; }       
    }
}
