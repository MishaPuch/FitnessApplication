using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixTreningDep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trenings_TypeOfMuscleGroups_MuscleGroupId",
                table: "Trenings");

            migrationBuilder.DropIndex(
                name: "IX_Trenings_MuscleGroupId",
                table: "Trenings");

            migrationBuilder.DropColumn(
                name: "MuscleGroupId",
                table: "Trenings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MuscleGroupId",
                table: "Trenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trenings_MuscleGroupId",
                table: "Trenings",
                column: "MuscleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trenings_TypeOfMuscleGroups_MuscleGroupId",
                table: "Trenings",
                column: "MuscleGroupId",
                principalTable: "TypeOfMuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
