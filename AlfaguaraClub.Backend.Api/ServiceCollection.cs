using AlfaguaraClub.Backend.Persistence.Data;
using AlfaguaraClub.Backend.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AlfaguaraClub.Backend.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomaizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 37))));

            services.AddScoped<ApplicationDbContextInitialiser>();
            services.AddAuthorizationBuilder();

            return services;
        }
        public static IServiceCollection AddCustomizedRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
