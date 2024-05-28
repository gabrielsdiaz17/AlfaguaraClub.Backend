using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IStoryRepository:IRepository<Story>
    {
        Task<List<Story>> GetStories();
        Task<Story> GetStoryByStoryId(long storyId);
        Task<List<Story>> GetQuantityStories(int quantity);
        Task<List<Story>> GetStoriesByCategory(int categoryId);
    }
}
