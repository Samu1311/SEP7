using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApiSEP7.Models;

namespace WebApiSEP7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Services.Any() || context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

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
                context.SaveChanges();
            }
        }
    }
}