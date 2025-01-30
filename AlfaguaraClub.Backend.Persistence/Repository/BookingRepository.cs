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
                                 .Include(book => book.User).Where(book => book.IsActive)
                                 .Include(book => book.SpaceActivity).ThenInclude(spaceactivity=> spaceactivity.Space)
                                 .Include(book => book.Membership).Where(book => book.Membership.IsActive)
                                 .Include(book => book.StatusBooking)
                                 .Include(book => book.SpaceActivitySlot).Where(book=> book.SpaceActivitySlot.IsActive)
                                 .FirstOrDefaultAsync();
            return booking;
        }

        public async Task<List<Booking>> GetBookings()
        {
            var bookings = await QueryNoTracking().Where(book=>book.IsActive)
                                 .Include(book => book.User).Where(book => book.User.IsActive)
                                 .Include(book => book.SpaceActivity).Where(book => book.SpaceActivity.IsActive)
                                 .Include(book => book.Membership).Where(book => book.Membership.IsActive)
                                 .Include(book => book.StatusBooking)
                                 .Include(book => book.SpaceActivitySlot).Where(book => book.SpaceActivitySlot.IsActive)
                                 .OrderByDescending(book=>book.BookingId)
                                 .ToListAsync();
            return bookings;    
        }

        public async Task<List<Booking>> GetBookingsByMembership(long membershipId)
        {
            var bookingsByMembership = await QueryNoTracking().Where(book=>book.MembershipId == membershipId && book.IsActive)
                                             .Include(book => book.User).Where(book => book.User.IsActive)
                                             .Include(book => book.SpaceActivity).Where(book => book.SpaceActivity.IsActive)
                                             .Include(book => book.Membership).Where(book => book.Membership.IsActive)
                                             .Include(book => book.StatusBooking)
                                             .Include(book => book.SpaceActivitySlot).Where(book => book.SpaceActivitySlot.IsActive)
                                             .OrderByDescending(book => book.BookingId)
                                             .ToListAsync();
            return bookingsByMembership;
        }

        public async Task<List<Booking>> GetBookingsBySpaceActivityId(long spaceActivityId)
        {
            var bookingsBySpaceActivity = await QueryNoTracking().Where(book => book.SpaceActivityId == spaceActivityId && book.IsActive)
                                             .Include(book => book.User).Where(book => book.User.IsActive)
                                             .Include(book => book.SpaceActivity)
                                             .Include(book => book.Membership).Where(book => book.Membership.IsActive)
                                             .Include(book => book.StatusBooking)
                                             .Include(book => book.SpaceActivitySlot).Where(book => book.SpaceActivitySlot.IsActive)
                                             .OrderByDescending(book => book.BookingId)
                                             .ToListAsync();
            return bookingsBySpaceActivity;
        }
    }
}
