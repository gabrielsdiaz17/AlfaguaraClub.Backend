using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class TaxRepository : BaseRepository<Tax>, ITaxRepository
    {
        public TaxRepository(IRepository<Tax> repository) : base(repository)
        {
        }

        public async Task<Tax> GetTaxById(int taxId)
        {
            var tax = await QueryNoTracking().Where(tax=> tax.TaxId == taxId).FirstOrDefaultAsync();
            return tax;
        }

        public async Task<Tax> GetTaxByName(string taxName)
        {
            var tax = await QueryNoTracking().Where(tax=>tax.TaxName == taxName).FirstOrDefaultAsync();
            return tax;
        }

        public async Task<List<Tax>> GetTaxesActive()
        {
            var taxes = await QueryNoTracking().Where(tax => tax.IsActive).ToListAsync();
            return taxes;
        }
    }
}
