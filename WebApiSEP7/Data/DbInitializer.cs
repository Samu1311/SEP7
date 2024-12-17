using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiSEP7.Models;
using WebApiSEP7.Services;
using WebApiSEP7.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Drop the database if it exists and create a new one
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var categories = new Category[]
            {
                new Category { CategoryId = 1, CategoryName = "Basic" },
                new Category { CategoryId = 2, CategoryName = "Heart" },
                new Category { CategoryId = 3, CategoryName = "Diabetes" },
                new Category { CategoryId = 4, CategoryName = "Premium" }
            };

            context.Categories.AddRange(categories);

            var services = new Service[]
            {
                new Service { ServiceId = 1, CategoryId = 1, ServiceName = "General Practitioner Consultations", Description = "Access to GP consultations for general healthcare needs.", Price = 50.00M },
                new Service { ServiceId = 2, CategoryId = 1, ServiceName = "Online Doctor Services", Description = "24/7 access to online consultations with licensed doctors.", Price = 40.00M },
                new Service { ServiceId = 3, CategoryId = 1, ServiceName = "Preventive Advice Line", Description = "Expert advice on preventive healthcare measures.", Price = 20.00M },
                new Service { ServiceId = 4, CategoryId = 1, ServiceName = "Physiotherapy and Chiropractic", Description = "Treatments for general musculoskeletal issues.", Price = 70.00M },
                new Service { ServiceId = 5, CategoryId = 1, ServiceName = "Access to Private Hospitals", Description = "Access to private hospitals for non-critical general health issues.", Price = 100.00M },
                new Service { ServiceId = 6, CategoryId = 2, ServiceName = "Cardiovascular Surgery", Description = "Advanced surgical treatments for cardiovascular conditions.", Price = 500.00M },
                new Service { ServiceId = 7, CategoryId = 2, ServiceName = "Cardiac Second Opinions", Description = "Get additional expert opinions on cardiac conditions.", Price = 150.00M },
                new Service { ServiceId = 8, CategoryId = 2, ServiceName = "Dietician Consultations for Heart Health", Description = "Personalized diet plans for heart health management.", Price = 80.00M },
                new Service { ServiceId = 9, CategoryId = 2, ServiceName = "Heart Rehabilitation", Description = "Post-surgery rehabilitation programs for cardiac patients.", Price = 300.00M },
                new Service { ServiceId = 10, CategoryId = 2, ServiceName = "Cardiac Diagnostic Imaging", Description = "Advanced imaging like echocardiograms and stress tests.", Price = 200.00M },
                new Service { ServiceId = 11, CategoryId = 3, ServiceName = "Endocrinology Specialist Consultations", Description = "Expert consultations on hormonal and metabolic health issues.", Price = 100.00M },
                new Service { ServiceId = 12, CategoryId = 3, ServiceName = "Glucose Monitoring and Support", Description = "Continuous glucose monitoring and insulin therapy support.", Price = 150.00M },
                new Service { ServiceId = 13, CategoryId = 3, ServiceName = "Dietician Consultations for Diabetes", Description = "Personalized nutrition plans for diabetes management.", Price = 80.00M },
                new Service { ServiceId = 14, CategoryId = 3, ServiceName = "Diabetes Testing Supplies", Description = "Coverage for routine blood sugar testing supplies and education.", Price = 50.00M },
                new Service { ServiceId = 15, CategoryId = 3, ServiceName = "Physiotherapy for Diabetes Complications", Description = "Care for diabetes-related physical complications like neuropathy.", Price = 70.00M }
            };

            context.Services.AddRange(services);

            var users = new User[]
            {
                new User { UserId = 1, FirstName = "Samuele", LastName = "Biondi", Email = "samuele@test.com", PasswordHash = PasswordHelper.HashPassword("password1"), PhoneNumber = "1234567890", DateOfBirth = new DateTime(1990, 1, 1), Gender = "Male", Discount = 0.1M, EmergencyContact = "Jane Doe", SubscriptionId = null },
                new User { UserId = 2, FirstName = "Ana", LastName = "Vieira", Email = "ana@test.com", PasswordHash = PasswordHelper.HashPassword("password2"), PhoneNumber = "0987654321", DateOfBirth = new DateTime(1985, 5, 15), Gender = "Female", Discount = 0.2M, EmergencyContact = "John Smith", SubscriptionId = null },
                new User { UserId = 3, FirstName = "Eliza", LastName = "Smela", Email = "eliza@test.com", PasswordHash = PasswordHelper.HashPassword("password3"), PhoneNumber = "1122334455", DateOfBirth = new DateTime(1975, 10, 20), Gender = "Female", Discount = 0.15M, EmergencyContact = "Bob Johnson", SubscriptionId = null },
                new User { UserId = 4, FirstName = "Eric", LastName = "Pinto", Email = "eric@test.com", PasswordHash = PasswordHelper.HashPassword("password4"), PhoneNumber = "5566778899", DateOfBirth = new DateTime(2000, 3, 30), Gender = "Male", Discount = 0.05M, EmergencyContact = "Alice Brown", SubscriptionId = null }
            };

            context.Users.AddRange(users);

            var personalInformations = new PersonalInformation[]
            {
                new PersonalInformation { PersonalInformationId = 1, UserId = 1, IsPregnant = false, Weight = 70, Height = 170, Smokes = false, ConsumesAlcohol = false },
                new PersonalInformation { PersonalInformationId = 2, UserId = 2, IsPregnant = true, Weight = 65, Height = 160, Smokes = false, ConsumesAlcohol = true },
                new PersonalInformation { PersonalInformationId = 3, UserId = 3, IsPregnant = false, Weight = 80, Height = 175, Smokes = true, ConsumesAlcohol = true },
                new PersonalInformation { PersonalInformationId = 4, UserId = 4, IsPregnant = false, Weight = 90, Height = 180, Smokes = true, ConsumesAlcohol = false }
            };

            context.PersonalInformations.AddRange(personalInformations);

            var medicalInformations = new MedicalInformation[]
            {
                new MedicalInformation { MedicalInformationId = 1, UserId = 1, Hypertension = 0, HeartDisease = 0, SmokingHistory = 0, BMI = 24.2f, HbA1cLevel = 5.5f, BloodGlucoseLevel = 90, RestingBP = 120, Cholesterol = 180, FastingBS = 0, MaxHR = 190, ExerciseAngina = 0, Oldpeak = 0.0f, ChestPainType = ChestPainType.TypicalAngina, STSlope = STSlope.Flat, RestingECG = RestingECG.RestingECG_Normal },
                new MedicalInformation { MedicalInformationId = 2, UserId = 2, Hypertension = 1, HeartDisease = 1, SmokingHistory = 1, BMI = 27.5f, HbA1cLevel = 6.8f, BloodGlucoseLevel = 140, RestingBP = 140, Cholesterol = 220, FastingBS = 1, MaxHR = 160, ExerciseAngina = 1, Oldpeak = 2.5f, ChestPainType = ChestPainType.AtypicalAngina, STSlope = STSlope.Downsloping, RestingECG = RestingECG.RestingECG_LVH },
                new MedicalInformation { MedicalInformationId = 3, UserId = 3, Hypertension = 1, HeartDisease = 0, SmokingHistory = 1, BMI = 29.4f, HbA1cLevel = 7.2f, BloodGlucoseLevel = 160, RestingBP = 130, Cholesterol = 210, FastingBS = 1, MaxHR = 150, ExerciseAngina = 0, Oldpeak = 1.0f, ChestPainType = ChestPainType.NonAnginalPain, STSlope = STSlope.Upsloping, RestingECG = RestingECG.RestingECG_ST },
                new MedicalInformation { MedicalInformationId = 4, UserId = 4, Hypertension = 0, HeartDisease = 0, SmokingHistory = 0, BMI = 22.0f, HbA1cLevel = 5.0f, BloodGlucoseLevel = 85, RestingBP = 110, Cholesterol = 170, FastingBS = 0, MaxHR = 200, ExerciseAngina = 0, Oldpeak = 0.0f, ChestPainType = ChestPainType.Asymptomatic, STSlope = STSlope.Flat, RestingECG = RestingECG.RestingECG_Normal }
            };

            context.MedicalInformations.AddRange(medicalInformations);

            context.SaveChanges();
        }
    }
}