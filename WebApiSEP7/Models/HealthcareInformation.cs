public class HealthcareInformation
{
    public int HealthcareInformationId { get; set; }

    // Foreign key
    public int UserId { get; set; }

    // Personal Information
    public string BloodType { get; set; }
    public string Exercise { get; set; }
    public string Pregnancy { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public bool Smoking { get; set; }
    public bool Alcohol { get; set; }
    public decimal? BMI { get; set; } // This can be calculated

    // Medical Information
    public decimal? GlucoseLevel { get; set; }
    public string BloodPressure { get; set; }
    public decimal? SkinThickness { get; set; }
    public decimal? InsulinLevel { get; set; }
    public string ChestPain { get; set; }
    public decimal? Cholesterol { get; set; }
    public string RestingECGResults { get; set; }
    public decimal? FastingBloodSugar { get; set; }
    public bool ExerciseInducedAngina { get; set; }
    public decimal? Saturation { get; set; }
    public bool YellowFingers { get; set; }
    public bool Anxiety { get; set; }
    public bool PeerPressure { get; set; }
    public bool ChronicDiseases { get; set; }
    public bool Fatigue { get; set; }
    public bool Allergies { get; set; }
    public bool Wheezing { get; set; }
    public bool Coughing { get; set; }
    public bool ShortnessOfBreath { get; set; }
    public bool SwallowingDifficulty { get; set; }

    // Navigation property
    public User User { get; set; }
}