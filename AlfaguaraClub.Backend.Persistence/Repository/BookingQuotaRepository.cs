using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class BookingQuotaRepository : BaseRepository<BookingQuota>, IBookingQuotaRepository
    {
        public BookingQuotaRepository(IRepository<BookingQuota> repository) : base(repository)
        {
        }
    }
}
