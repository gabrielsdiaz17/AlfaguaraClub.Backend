using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        public ParameterRepository(IRepository<Parameter> repository) : base(repository)
        {
        }

        public async Task<Parameter> GetParameterById(long parameterId)
        {
            var parameter = await QueryNoTracking().Where(param=> param.ParameterId == parameterId)                                                   
                                                   .FirstOrDefaultAsync();
            return parameter;
        }

        public async Task<Parameter> GetParameterByName(string name)
        {
            var parameter = await QueryNoTracking().Where(param => param.ParameterName == name)
                                                   .FirstOrDefaultAsync();
            return parameter;
        }

        public async Task<List<Parameter>> GetParameters()
        {
            var listParameters = await QueryNoTracking().Where(param=> param.IsActive).OrderByDescending(param => param.ParameterId).ToListAsync();   
            return listParameters;
        }
    }
}
