public class Subscription
{
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation properties
    public ICollection<SubscriptionCategory> SubscriptionCategories { get; set; }
    public ICollection<User> Users { get; set; }
}
