using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponPurchasesQueryCommands
{
    public class CouponPurchaseVm
    {
        public long CouponPurchaseId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }        
        public string? Comment { get; set; }
        public long? CostCenterId { get; set; }
        public CostCenterDto CostCenter { get; set; }
        public long? UserId { get; set; }
        public UserDto User { get; set; }
    }
}
