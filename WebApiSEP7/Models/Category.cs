public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    // Navigation property
    public ICollection<Service> Services { get; set; }
    public ICollection<SubscriptionCategory> SubscriptionCategories { get; set; }
}
