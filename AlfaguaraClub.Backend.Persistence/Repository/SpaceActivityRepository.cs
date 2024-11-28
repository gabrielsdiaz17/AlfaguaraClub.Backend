using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class SpaceActivityRepository : BaseRepository<SpaceActivity>, ISpaceActivityRepository
    {
        public SpaceActivityRepository(IRepository<SpaceActivity> repository) : base(repository)
        {
        }

        public async Task<SpaceActivity> GetSingleSpaceActivity(long spaceActivityId)
        {
            var spaceActivity = await QueryNoTracking().Where(sp=> sp.SpaceActivityId == spaceActivityId)                  
                                                       .Include(sp=> sp.Bookings).FirstOrDefaultAsync();
            return spaceActivity;
        }

        public async Task<List<SpaceActivity>> GetSpaceActivitiesByDate(DateTime date)
        {
            var activitiesDate = await QueryNoTracking().Where(ac=> ac.IsActive && ac.ActivityDate.Date == date.Date).ToListAsync();
            return activitiesDate;
        }

        public async Task<List<SpaceActivity>> GetSpaceActivitiesWithBooking()
        {
            var activities = await QueryNoTracking().Where(ac=> ac.IsActive)
                                                    .OrderByDescending(ac=> ac.SpaceActivityId)
                                                    .Include(ac=> ac.Bookings).ToListAsync();
            return activities;
        }

        public async Task<List<SpaceActivity>> GetSpaceActivityBySpace(long spaceId)
        {
            var spaceActivity = await QueryNoTracking().Where(sp=> sp.SpaceId == spaceId && sp.IsActive)
                                                       .Include(sp=> sp.Bookings)
                                                       .OrderByDescending(ac => ac.SpaceActivityId)
                                                       .ToListAsync();
            return spaceActivity;
        }
    }
}
