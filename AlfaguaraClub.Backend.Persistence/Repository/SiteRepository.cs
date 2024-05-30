using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class SiteRepository : BaseRepository<Site>, ISiteRepository
    {
        public SiteRepository(IRepository<Site> repository) : base(repository)
        {
        }

        public async Task<List<Site>> GetSiteWithCostCenter()
        {
            var listSites = await QueryNoTracking().Where(site=> site.IsActive)
                                                   .OrderByDescending(site=>site.SiteId)
                                                   .Include(site=>site.CostCenters).ToListAsync();
            return listSites;
        }
    }
}
