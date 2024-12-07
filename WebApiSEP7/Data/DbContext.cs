using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<HealthcareInformation> HealthcareInformations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<SubscriptionCategory>()
            .HasOne(sc => sc.Category)
            .WithMany(c => c.SubscriptionCategories)
            .HasForeignKey(sc => sc.CategoryId);

        modelBuilder.Entity<SubscriptionCategory>()
            .HasOne(sc => sc.Subscription)
            .WithMany(s => s.SubscriptionCategories)
            .HasForeignKey(sc => sc.SubscriptionId);

        modelBuilder.Entity<Service>()
            .HasOne(s => s.Category)
            .WithMany(c => c.Services)
            .HasForeignKey(s => s.CategoryId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Subscription)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.SubscriptionId)
            .OnDelete(DeleteBehavior.SetNull); // Handle nullable foreign key

        modelBuilder.Entity<User>()
            .HasOne(u => u.HealthcareInformation)
            .WithOne(hi => hi.User)
            .HasForeignKey<HealthcareInformation>(hi => hi.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Ensure cascading delete
    }
}