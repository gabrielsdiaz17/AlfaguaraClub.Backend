using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IBookingRepository: IRepository<Booking>
    {
        Task<Booking> GetBookingDetailByBookingId(long bookingId);
        Task<List<Booking>> GetBookings();
        Task<List<Booking>> GetBookingsByMembership(long membershipId);
        Task<List<Booking>> GetBookingsBySpaceActivityId(long spaceActivityId);
    }
}
