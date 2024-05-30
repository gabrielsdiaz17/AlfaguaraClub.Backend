using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(IRepository<Booking> repository) : base(repository)
        {
        }

        public async Task<Booking> GetBookingDetailByBookingId(long bookingId)
        {
            var booking = await QueryNoTracking().Where(book => book.BookingId == bookingId)
                                 .Include(book => book.User)
                                 .Include(book => book.SpaceActivity)
                                 .Include(book => book.Membership)
                                 .Include(book => book.StatusBooking)
                                 .FirstOrDefaultAsync();
            return booking;
        }

        public async Task<List<Booking>> GetBookings()
        {
            var bookings = await QueryNoTracking().Where(book=>book.IsActive)
                                 .Include(book => book.User)
                                 .Include(book => book.SpaceActivity)
                                 .Include(book => book.Membership)
                                 .Include(book => book.StatusBooking)
                                 .OrderByDescending(book=>book.BookingId)
                                 .ToListAsync();
            return bookings;    
        }

        public async Task<List<Booking>> GetBookingsByMembership(long membershipId)
        {
            var bookingsByMembership = await QueryNoTracking().Where(book=>book.MembershipId == membershipId)
                                             .Include(book => book.User)
                                             .Include(book => book.SpaceActivity)
                                             .Include(book => book.Membership)
                                             .Include(book => book.StatusBooking)
                                             .OrderByDescending(book => book.BookingId)
                                             .ToListAsync();
            return bookingsByMembership;
        }

        public async Task<List<Booking>> GetBookingsBySpaceActivityId(long spaceActivityId)
        {
            var bookingsBySpaceActivity = await QueryNoTracking().Where(book => book.SpaceActivityId == spaceActivityId)
                                             .Include(book => book.User)
                                             .Include(book => book.SpaceActivity)
                                             .Include(book => book.Membership)
                                             .Include(book => book.StatusBooking)
                                             .OrderByDescending(book => book.BookingId)
                                             .ToListAsync();
            return bookingsBySpaceActivity;
        }
    }
}
