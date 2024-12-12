namespace WebApiSEP7.Models // Ensure this is the correct namespace for your models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation properties
        public ICollection<Service> Services { get; set; }
        public ICollection<SubscriptionCategory> SubscriptionCategories { get; set; }
    }
}