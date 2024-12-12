namespace WebApiSEP7.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal? Discount { get; set; }
        public string EmergencyContact { get; set; }

        // Foreign key
        public int? SubscriptionId { get; set; }

        // Navigation properties
        public Subscription? Subscription { get; set; }
        public HealthcareInformation? HealthcareInformation { get; set; }
    }
}