namespace WebApiSEP7.Models // Ensure this is the correct namespace for your models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}