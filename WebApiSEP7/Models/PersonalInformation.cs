using System.Text.Json.Serialization;

namespace WebApiSEP7.Models
{
    public class PersonalInformation
    {
        public int PersonalInformationId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public bool IsPregnant { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public bool Smokes { get; set; }
        public bool ConsumesAlcohol { get; set; }

        // Navigation property
        [JsonIgnore]
        public User? User { get; set; } // Reference to the User entity
    }
}