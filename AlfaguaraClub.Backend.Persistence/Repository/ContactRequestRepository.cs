using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class ContactRequestRepository : BaseRepository<ContactRequest>, IContactRequestRepository
    {
        public ContactRequestRepository(IRepository<ContactRequest> repository) : base(repository)
        {
        }

        public async Task<List<ContactRequest>> GetAllRequest()
        {
            var contactRequests= await QueryNoTracking().Where(request=> request.IsActive)
                                                        .OrderByDescending(request=>request.ContactRequestId)
                                                        .ToListAsync();
            return contactRequests;
        }

        public async Task<List<ContactRequest>> GetRequestBySpaceId(long spaceId)
        {
            var requestSpace = await QueryNoTracking().Where(request=>request.SpaceId == spaceId && request.IsActive)
                                                      .Include(request=>request.Space)
                                                      .OrderByDescending(request=>request.ContactRequestId)
                                                      .ToListAsync();
            return requestSpace;
        }

        public async Task<List<ContactRequest>> GetRequestByStatus(StatusRequest status)
        {
            var requestByStatus = await QueryNoTracking().Where(request=> request.StatusRequest == status && request.IsActive)
                                                         .Include(request=>request.Space)
                                                         .OrderByDescending (request=>request.ContactRequestId)
                                                         .ToListAsync();
            return requestByStatus;
        }
    }
}
