using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSEP7.Migrations
{
    /// <inheritdoc />
    public partial class QuestionsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsResults_Subscriptions_SubscriptionId",
                table: "QuestionsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsResults_SubscriptionId",
                table: "QuestionsResults");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsResults_UserId",
                table: "QuestionsResults");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "QuestionsResults");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResults_UserId",
                table: "QuestionsResults",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsResults_UserId",
                table: "QuestionsResults");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "QuestionsResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResults_SubscriptionId",
                table: "QuestionsResults",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResults_UserId",
                table: "QuestionsResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsResults_Subscriptions_SubscriptionId",
                table: "QuestionsResults",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }
    }
}
