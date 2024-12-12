namespace WebApiSEP7.Models // Ensure this is the correct namespace for your models
{
    public class SubscriptionCategory
    {
        public int SubscriptionCategoryId { get; set; }

        // Foreign keys
        public int CategoryId { get; set; }
        public int SubscriptionId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public Subscription Subscription { get; set; }
    }
}