using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class SpaceRepository : BaseRepository<Space>, ISpaceRepository
    {
        public SpaceRepository(IRepository<Space> repository) : base(repository)
        {
        }

        public async Task<Space> GetSpace(long spaceId)
        {
            var space = await QueryNoTracking().Where(space => space.SpaceId == spaceId)
                                                .Include(space => space.Pictures)
                                                .Include(space => space.SpaceActivities)
                                                .FirstOrDefaultAsync();
            return space;
        }

        public async Task<List<Space>> GetSpacesWithImagesIncludeActivities(int? quantityRecords)
        {
            var quantity = quantityRecords == 0 ? 10 : quantityRecords;
            var allSpaces = await QueryNoTracking().Where(space => space.IsActive)
                                                   .Include(space => space.Pictures)
                                                   .Include(space => space.SpaceActivities)
                                                   .Include(space => space.CostCenter)
                                                   .Take((int)quantity)
                                                   .OrderByDescending(space => space.SpaceId)
                                                   .ToListAsync();
                                                   
            return allSpaces;
        }
        
    }
}
