﻿using AlfaguaraClub.Backend.Application.Contracts.Persistence;
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
            services.AddTransient<IBillingDetailRepository, BillingDetailRepository>();
            services.AddTransient<IBillingRepository, BillingRepository>();
            services.AddTransient<IBillingStatusRepository, BillingStatusRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICostCenterRepository, CostCenterRepository>();
            services.AddTransient<IIdentificationTypeRepository, IdentificationTypeRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddTransient<IParameterRepository, ParameterRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IPictureRepository, PictureRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<ISpaceActivityRepository, SpaceActivityRepository>();
            services.AddTransient<ISpaceRepository, SpaceRepository>();
            services.AddTransient<IStatusBookingRepository, StatusBookingRepository>();
            services.AddTransient<IStoryRepository, StoryRepository>();
            services.AddTransient<ITaxRepository, TaxRepository>();
            services.AddTransient<ITypeActivityRepository, TypeActivityRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
