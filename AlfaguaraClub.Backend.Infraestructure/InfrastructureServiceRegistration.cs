using AlfaguaraClub.Backend.Application.Contracts.Infraestructure;
using AlfaguaraClub.Backend.Infraestructure.Authentication;
using AlfaguaraClub.Backend.Infraestructure.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJWTProvider, JWTProvider>();
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
