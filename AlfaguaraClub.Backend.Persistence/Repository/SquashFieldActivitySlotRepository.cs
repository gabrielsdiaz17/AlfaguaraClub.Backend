using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class SquashFieldActivitySlotRepository : BaseRepository<SquashFieldActivitySlot>, ISquashFieldActivitySlotRepository
    {
        public SquashFieldActivitySlotRepository(IRepository<SquashFieldActivitySlot> repository) : base(repository)
        {
        }

        public async Task<List<SquashFieldActivitySlot>> GetSquashSlotsFroSpaceActivity(long spaceActivityId)
        {
            var slots = await QueryNoTracking().Where(sq=> sq.IsActive && sq.SpaceActivityId == spaceActivityId).ToListAsync();
            return slots;
        }
    }
}
