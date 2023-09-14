using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixTypeOfMuscleGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FullBodyWorkoutProtogonistMuscleGroups",
                table: "TypeOfMuscleGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullBodyWorkoutProtogonistMuscleGroups",
                table: "TypeOfMuscleGroups");
        }
    }
}
