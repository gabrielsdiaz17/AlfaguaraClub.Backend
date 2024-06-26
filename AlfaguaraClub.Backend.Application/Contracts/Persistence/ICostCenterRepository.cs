﻿using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface ICostCenterRepository: IRepository<CostCenter>
    {
        Task<List<CostCenter>> GetCostCenterWithSpaces();
        Task<CostCenter> GetCostCenter(long costCenterId);

    }
}
