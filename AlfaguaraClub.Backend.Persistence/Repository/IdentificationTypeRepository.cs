using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class IdentificationTypeRepository : BaseRepository<IIdentificationTypeRepository>
    {
        public IdentificationTypeRepository(IRepository<IIdentificationTypeRepository> repository) : base(repository)
        {
        }
    }
}
