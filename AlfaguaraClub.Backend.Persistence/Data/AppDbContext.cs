using AlfaguaraClub.Backend;
using AlfaguaraClub.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<BillingDetail> BillingDetail { get; set; }
        public DbSet<BillingStatus> BillingStatus { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ContactRequest> ContactRequest { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<IdentificationType> IdentificationType { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<Space> Space { get; set; }
        public DbSet<SpaceActivity> SpaceActivity { get; set; }
        public DbSet<StatusBooking> StatusBooking { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<TypeActivity> TypeActivity { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<BookingQuota> BookingQuota { get; set; }
        public DbSet<SpaceActivitySlot> SpaceActivitySlot { get; set; }
        public DbSet<TennisFieldActivitySlot> TennisFieldActivitySlot { get; set; }
        public DbSet<SquashFieldActivitySlot> SquashFieldActivitySlot { get; set; }
        public DbSet<MonthlyCouponBook> MonthlyCouponBook { get; set; }
        public DbSet<CouponPurchase> CouponPurchase { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
