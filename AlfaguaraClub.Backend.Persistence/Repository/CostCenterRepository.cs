using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class CostCenterRepository : BaseRepository<CostCenter>, ICostCenterRepository
    {
        public CostCenterRepository(IRepository<CostCenter> repository) : base(repository)
        {
        }

        public async Task<CostCenter> GetCostCenter(long costCenterId)
        {
            var costCenter = await QueryNoTracking().Where(cost => cost.CostCenterId == costCenterId)
                                                    .Include(cost=>cost.Spaces)
                                                    .Include(cost=> cost.Products)
                                                    .FirstOrDefaultAsync();
            return costCenter;
        }

        public async Task<List<CostCenter>> GetCostCenterWithSpaces()
        {
            var cc = await QueryNoTracking().Where(cc=>cc.IsActive)
                                            .Include(cc=>cc.Spaces)
                                            .Include(cc=>cc.Products)
                                            .ToListAsync();
            return cc;
        }
    }
}
