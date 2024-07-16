using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IContactRequestRepository: IRepository<ContactRequest>
    {
        Task<List<ContactRequest>> GetRequestByStatus(StatusRequest status);
        Task<List<ContactRequest>> GetRequestBySpaceId(long spaceId);
        Task<List<ContactRequest>> GetAllRequest();


    }
}
