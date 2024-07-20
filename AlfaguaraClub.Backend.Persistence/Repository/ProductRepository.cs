using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IRepository<Product> repository) : base(repository)
        {
        }

        public async Task<Product> GetProductByCode(string code)
        {
            var product = await QueryNoTracking().Where(product=>product.ProductCode == code)
                                                 .Include(product=>product.Tax)
                                                 .Include(product=> product.Pictures)
                                                 .FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> GetProductById(long id)
        {
            var product = await QueryNoTracking().Where(product=>product.ProductId == id)
                                                 .Include(product => product.Tax)
                                                 .Include(product => product.Pictures)
                                                 .FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetProductsActive()
        {
            var products = await QueryNoTracking().Where(product=> product.IsActive)
                                                  .Include(product => product.Tax)
                                                  .Include(product => product.Pictures)
                                                  .OrderByDescending(product => product.ProductId)
                                                  .ToListAsync();
            return products;
        }
    }
}
