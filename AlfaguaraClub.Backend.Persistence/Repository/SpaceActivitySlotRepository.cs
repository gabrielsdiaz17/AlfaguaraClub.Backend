using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class SpaceActivitySlotRepository : BaseRepository<SpaceActivitySlot>, ISpaceActivitySlotRepository
    {
        public SpaceActivitySlotRepository(IRepository<SpaceActivitySlot> repository) : base(repository)
        {
        }

        public async Task<List<SpaceActivitySlot>> GetSlotsForSpaceActivity(long spaceActivityId)
        {
            var slot = await QueryNoTracking().Where(s => s.IsActive && s.SpaceActivityId == spaceActivityId).ToListAsync();
            return slot;
        }
    }
}
