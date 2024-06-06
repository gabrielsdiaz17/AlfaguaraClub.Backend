using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class StatusBookingRepository : BaseRepository<StatusBooking>, IStatusBookingRepository
    {
        public StatusBookingRepository(IRepository<StatusBooking> repository) : base(repository)
        {
        }

        public async Task<List<StatusBooking>> GetStatusBooking()
        {
            var statusBookings= await QueryNoTracking().Where(st=>st.IsActive)
                                                       .OrderByDescending(st=>st.StatusBookingId).ToListAsync();
            return statusBookings;
        }
    }
}
