using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await QueryNoTracking().Where(category=> category.IsActive).ToListAsync();
            return categories;
        }
    }
}
