﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApiSEP7.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HealthcareInformation", b =>
                {
                    b.Property<int>("HealthcareInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Alcohol")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Allergies")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Anxiety")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("BMI")
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodPressure")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChestPain")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Cholesterol")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ChronicDiseases")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Coughing")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Exercise")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ExerciseInducedAngina")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("FastingBloodSugar")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Fatigue")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("GlucoseLevel")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Height")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("InsulinLevel")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PeerPressure")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pregnancy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RestingECGResults")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Saturation")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShortnessOfBreath")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("SkinThickness")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Smoking")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SwallowingDifficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Wheezing")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("YellowFingers")
                        .HasColumnType("INTEGER");

                    b.HasKey("HealthcareInformationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("HealthcareInformations");
                });

            modelBuilder.Entity("Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SubscriptionCategory", b =>
                {
                    b.Property<int>("SubscriptionCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubscriptionCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionCategories");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyContact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthcareInformation", b =>
                {
                    b.HasOne("User", "User")
                        .WithOne("HealthcareInformation")
                        .HasForeignKey("HealthcareInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Service", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SubscriptionCategory", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany("SubscriptionCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Subscription", "Subscription")
                        .WithMany("SubscriptionCategories")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("Subscription", "Subscription")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("SubscriptionCategories");
                });

            modelBuilder.Entity("Subscription", b =>
                {
                    b.Navigation("SubscriptionCategories");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("HealthcareInformation");
                });
#pragma warning restore 612, 618
        }
    }
}