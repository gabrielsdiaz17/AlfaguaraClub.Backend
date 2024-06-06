using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IRepository<Company> repository) : base(repository)
        {
        }

        public async Task<bool> IsCompanyNameAndIdentifierUnique(string companyName, string companyIdentifier)
        {
            var matches = await QueryNoTracking().Where(c=>c.CompanyName == companyName && c.CompanyIdentifier == companyIdentifier).AnyAsync();
            return await Task.FromResult(matches);
        }
    }
}
