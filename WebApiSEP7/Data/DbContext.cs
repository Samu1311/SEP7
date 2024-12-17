using Microsoft.EntityFrameworkCore;
using WebApiSEP7.Models;

namespace WebApiSEP7.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalInformation> MedicalInformations { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<CustomerSatisfaction> CustomerSatisfactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary keys and relationships if needed
            modelBuilder.Entity<MedicalInformation>()
                .HasKey(mi => mi.MedicalInformationId);

            modelBuilder.Entity<PersonalInformation>()
                .HasKey(pi => pi.PersonalInformationId);

            // Configure one-to-one relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.MedicalInformation)
                .WithOne(mi => mi.User)
                .HasForeignKey<MedicalInformation>(mi => mi.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.PersonalInformation)
                .WithOne(pi => pi.User)
                .HasForeignKey<PersonalInformation>(pi => pi.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CustomerSatisfaction)
                .WithOne(pi => pi.User)
                .HasForeignKey<CustomerSatisfaction>(pi => pi.UserId);    
        }
    }
}