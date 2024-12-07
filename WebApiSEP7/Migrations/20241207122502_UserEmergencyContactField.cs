using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSEP7.Migrations
{
    /// <inheritdoc />
    public partial class UserEmergencyContactField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "Users");
        }
    }
}
