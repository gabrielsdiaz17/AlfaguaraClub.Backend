using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface ITaxRepository: IRepository<Tax>
    {
        Task<List<Tax>> GetTaxesActive();
        Task<Tax> GetTaxById(int taxId);
        Task<Tax> GetTaxByName(string taxName);
    }
}
