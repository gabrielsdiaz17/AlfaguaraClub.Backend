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

        public async Task<List<Space>> GetSpacesWithImagesIncludeActivities(int? quantityRecords)
        {
            var allSpaces = await QueryNoTracking().Where(space => space.IsActive)
                                                   .Include(space=>space.Pictures)
                                                   .Include(space=> space.SpaceActivities)
                                                   .Take(quantityRecords ?? 11)
                                                   .OrderByDescending(space => space.SpaceId)
                                                   .ToListAsync();
                                                   
            return allSpaces;
        }
    }
}
