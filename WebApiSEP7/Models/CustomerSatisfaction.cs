using System.Text.Json.Serialization;
 
namespace WebApiSEP7.Models 
{
    public class CustomerSatisfaction{

        public int CustomerSatisfactionId { get; set; } 

        public int Satisfaction { get; set; }

        public int Usability { get; set; }

        public int Comfort { get; set; }

        public int Transparency { get; set; }

        public int Recommendation { get; set; }

        public int Score { get; set; }

        // Foreign key
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; } // Reference to the User entity
    }
}