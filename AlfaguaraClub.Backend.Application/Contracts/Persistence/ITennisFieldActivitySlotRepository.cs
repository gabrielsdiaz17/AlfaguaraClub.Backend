using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface ITennisFieldActivitySlotRepository: IRepository<TennisFieldActivitySlot>
    {
        Task<List<TennisFieldActivitySlot>> GetTennisFieldSlotsForSpaceActivity(long spaceActivityId);
    }
}
