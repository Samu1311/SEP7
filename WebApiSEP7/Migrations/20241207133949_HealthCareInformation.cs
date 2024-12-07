using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSEP7.Migrations
{
    /// <inheritdoc />
    public partial class HealthCareInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionsResults");

            migrationBuilder.CreateTable(
                name: "HealthcareInformations",
                columns: table => new
                {
                    HealthcareInformationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BloodType = table.Column<string>(type: "TEXT", nullable: false),
                    Exercise = table.Column<string>(type: "TEXT", nullable: false),
                    Pregnancy = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: true),
                    Height = table.Column<decimal>(type: "TEXT", nullable: true),
                    Smoking = table.Column<bool>(type: "INTEGER", nullable: false),
                    Alcohol = table.Column<bool>(type: "INTEGER", nullable: false),
                    BMI = table.Column<decimal>(type: "TEXT", nullable: true),
                    GlucoseLevel = table.Column<decimal>(type: "TEXT", nullable: true),
                    BloodPressure = table.Column<string>(type: "TEXT", nullable: false),
                    SkinThickness = table.Column<decimal>(type: "TEXT", nullable: true),
                    InsulinLevel = table.Column<decimal>(type: "TEXT", nullable: true),
                    ChestPain = table.Column<string>(type: "TEXT", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "TEXT", nullable: true),
                    RestingECGResults = table.Column<string>(type: "TEXT", nullable: false),
                    FastingBloodSugar = table.Column<decimal>(type: "TEXT", nullable: true),
                    ExerciseInducedAngina = table.Column<bool>(type: "INTEGER", nullable: false),
                    Saturation = table.Column<decimal>(type: "TEXT", nullable: true),
                    YellowFingers = table.Column<bool>(type: "INTEGER", nullable: false),
                    Anxiety = table.Column<bool>(type: "INTEGER", nullable: false),
                    PeerPressure = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChronicDiseases = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fatigue = table.Column<bool>(type: "INTEGER", nullable: false),
                    Allergies = table.Column<bool>(type: "INTEGER", nullable: false),
                    Wheezing = table.Column<bool>(type: "INTEGER", nullable: false),
                    Coughing = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShortnessOfBreath = table.Column<bool>(type: "INTEGER", nullable: false),
                    SwallowingDifficulty = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareInformations", x => x.HealthcareInformationId);
                    table.ForeignKey(
                        name: "FK_HealthcareInformations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareInformations_UserId",
                table: "HealthcareInformations",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthcareInformations");

            migrationBuilder.CreateTable(
                name: "QuestionsResults",
                columns: table => new
                {
                    QuestionsResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicalData = table.Column<string>(type: "TEXT", nullable: false),
                    PreferencesData = table.Column<string>(type: "TEXT", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsResults", x => x.QuestionsResultId);
                    table.ForeignKey(
                        name: "FK_QuestionsResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResults_UserId",
                table: "QuestionsResults",
                column: "UserId",
                unique: true);
        }
    }
}
