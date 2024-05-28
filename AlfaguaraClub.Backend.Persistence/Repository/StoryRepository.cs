using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(IRepository<Story> repository) : base(repository)
        {
        }

        public async Task<List<Story>> GetQuantityStories(int quantity)
        {
            var quantityStories = await QueryNoTracking().Where(story=> story.IsActive)
                                                         .Include(story=> story.Category).Include(story=> story.Activity).Include(story=> story.Pictures)
                                                         .Take(quantity)
                                                         .OrderByDescending(story=> story.StoryPublishDate)
                                                         .ToListAsync();
            return quantityStories;
        }

        public async Task<List<Story>> GetStories()
        {
            var stories = await QueryNoTracking().Where(story=> story.IsActive)
                                                 .Include(story => story.Category).Include(story => story.Activity).Include(story => story.Pictures)
                                                 .OrderByDescending(story => story.PriorityRating)
                                                 .OrderByDescending(story=> story.StoryPublishDate)
                                                 .ToListAsync();
            return stories;
        }

        public async Task<List<Story>> GetStoriesByCategory(int categoryId)
        {
            var storiesByCategory = await QueryNoTracking().Where(story => story.CategoryId == categoryId && story.IsActive)
                                                           .Include(story => story.Category).Include(story => story.Activity).Include(story => story.Pictures)
                                                           .OrderByDescending(story => story.StoryPublishDate)
                                                           .ToListAsync();
            return storiesByCategory;
        }

        public async Task<Story> GetStoryByStoryId(long storyId)
        {
            var story = await QueryNoTracking().Where(story => story.StoryId == storyId)
                                              .Include(story => story.Category).Include(story => story.Activity).Include(story => story.Pictures)
                                              .FirstOrDefaultAsync();
            return story;
        }
    }
}
