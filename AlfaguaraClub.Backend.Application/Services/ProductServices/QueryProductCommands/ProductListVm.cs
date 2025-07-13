using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands;
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
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int? TaxId { get; set; }
        public TaxDto Tax { get; set; }
        public long? CostCenterId { get; set; }
        public CostCenterDto CostCenter { get; set; }
        public bool IsActive { get; set; }
        public bool PublicVisibility { get; set; }

        public ICollection<PictureDto> Pictures { get; set; }

    }
}
