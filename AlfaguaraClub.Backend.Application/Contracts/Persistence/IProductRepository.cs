using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<List<Product>> GetProductsActive();
        Task<Product> GetProductById(long id);
        Task<Product> GetProductByCode(string code);
    }
}
