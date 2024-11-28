using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface ISpaceActivityRepository: IRepository<SpaceActivity>
    {
        Task<List<SpaceActivity>> GetSpaceActivitiesWithBooking();
        Task<List<SpaceActivity>> GetSpaceActivityBySpace(long spaceId);
        Task<SpaceActivity> GetSingleSpaceActivity(long spaceActivityId);
        Task<List<SpaceActivity>> GetSpaceActivitiesByDate(DateTime date);
    }
}
