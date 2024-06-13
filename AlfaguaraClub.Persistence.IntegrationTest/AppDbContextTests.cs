using AlfaguaraClub.Backend.Domain.Entities;
using AlfaguaraClub.Backend.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Persistence.IntegrationTest
{
    public class AppDbContextTests
    {
        private readonly AppDbContext _appDbContext;
        public AppDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _appDbContext = new AppDbContext(dbContextOptions);
        }
        [Fact]
        public async void SaveIdentificationType()
        {
            var identificationType = new IdentificationType() { IdentificationTypeCode = 1, Nomenclature = "CC", Description = "Cédula de ciudadanía" };
            _appDbContext.IdentificationType.Add(identificationType);
            await _appDbContext.SaveChangesAsync();
            identificationType.IdendificationTypeId.ShouldBeOfType<int>();
        }

    }
}
