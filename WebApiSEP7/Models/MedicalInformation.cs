using System.Text.Json.Serialization;

namespace WebApiSEP7.Models // Ensure this is the correct namespace for your models
{
    public class MedicalInformation
    {
        public int MedicalInformationId { get; set; } // Primary Key

        // Foreign key
        public int UserId { get; set; }

        // Health Conditions
        public int Hypertension { get; set; } // 0 = No, 1 = Yes
        public int HeartDisease { get; set; } // 0 = No, 1 = Yes
        public int Diabetes { get; set; } // 0 = No, 1 = Yes

        // Lifestyle Information
        public int SmokingHistory { get; set; } // Coded value representing history of smoking

        // Health Metrics
        public float BMI { get; set; }
        public float HbA1cLevel { get; set; }
        public int BloodGlucoseLevel { get; set; }

        // Heart Health Specific Information
        public int RestingBP { get; set; } // Resting Blood Pressure
        public int Cholesterol { get; set; }
        public int FastingBS { get; set; } // Fasting Blood Sugar: 0 = <120 mg/dl, 1 = >120 mg/dl
        public int MaxHR { get; set; } // Maximum Heart Rate Achieved
        public int ExerciseAngina { get; set; } // 0 = No, 1 = Yes
        public float Oldpeak { get; set; } // ST depression induced by exercise relative to rest

        // Chest Pain Types (One-Hot Encoded)
        public ChestPainType ChestPainType { get; set; }

        // ST Slope Indicators (One-Hot Encoded)
        public STSlope STSlope { get; set; }

        // Resting ECG Results (One-Hot Encoded)
        public RestingECG RestingECG { get; set; }

        // Navigation property
        [JsonIgnore]
        public User? User { get; set; } // Reference to the User entity

            public float[] ToDiabetesFeaturesArray()
    {
        return new float[] { Hypertension, HeartDisease, Diabetes, SmokingHistory, BMI, HbA1cLevel, BloodGlucoseLevel };
    }

    public float[] ToHeartFeaturesArray()
    {
        return new float[] { RestingBP, Cholesterol, FastingBS, MaxHR, ExerciseAngina, Oldpeak, (float)ChestPainType, (float)STSlope, (float)RestingECG, };
    }
    }

    public enum STSlope
    {
        Upsloping = 0,
        Flat = 1,
        Downsloping = 2
    }

    public enum ChestPainType
    {
        TypicalAngina = 0,
        AtypicalAngina = 1,
        NonAnginalPain = 2,
        Asymptomatic = 3
    }

    public enum RestingECG
    {
        RestingECG_LVH = 0,
        RestingECG_Normal = 1,
        RestingECG_ST = 2
    }

}