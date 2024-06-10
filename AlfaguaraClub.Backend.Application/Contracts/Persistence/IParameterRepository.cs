using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IParameterRepository: IRepository<Parameter>
    {
        Task<List<Parameter>> GetParameters();
        Task<Parameter> GetParameterById(long parameterId);
        Task<Parameter> GetParameterByName(string name);
    }
}
