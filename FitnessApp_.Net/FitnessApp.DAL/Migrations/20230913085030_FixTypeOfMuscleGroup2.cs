using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixTypeOfMuscleGroup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FullBodyWorkoutProtogonistMuscleGroups",
                table: "TypeOfMuscleGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "FullBodyWorkoutProtogonistMuscleGroups",
                table: "TypeOfMuscleGroups",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
