using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakingConnectionTreningPlanWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreningPlan",
                table: "Users",
                newName: "TreningPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TreningPlanId",
                table: "Users",
                column: "TreningPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TreningPlans_TreningPlanId",
                table: "Users",
                column: "TreningPlanId",
                principalTable: "TreningPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TreningPlans_TreningPlanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TreningPlanId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TreningPlanId",
                table: "Users",
                newName: "TreningPlan");
        }
    }
}
