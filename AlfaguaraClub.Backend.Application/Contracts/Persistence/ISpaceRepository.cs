using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface ISpaceRepository: IRepository<Space>
    {
        Task<List<Space>> GetSpacesWithImagesIncludeActivities(int? quantityRecords);
        Task<Space> GetSpace(long spaceId);
    }
}
