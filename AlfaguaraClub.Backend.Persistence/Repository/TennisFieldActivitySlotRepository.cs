using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class TennisFieldActivitySlotRepository : BaseRepository<TennisFieldActivitySlot>, ITennisFieldActivitySlotRepository
    {
        public TennisFieldActivitySlotRepository(IRepository<TennisFieldActivitySlot> repository) : base(repository)
        {
        }

        public async Task<List<TennisFieldActivitySlot>> GetTennisFieldSlotsForSpaceActivity(long spaceActivityId)
        {
            var tennisSlots = await QueryNoTracking().Where(ts=> ts.IsActive && ts.SpaceActivityId == spaceActivityId).ToListAsync();
            return tennisSlots;
        }
    }
}
