using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfExercise",
                table: "Trenings",
                newName: "MuscleGroup");

            migrationBuilder.RenameColumn(
                name: "CalorificValue",
                table: "Diet",
                newName: "DayId");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "DaysofDiet",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "DaysofDiet",
                newName: "TreningId");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "DaysofDiet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayId",
                table: "DaysofDiet");

            migrationBuilder.RenameColumn(
                name: "MuscleGroup",
                table: "Trenings",
                newName: "TypeOfExercise");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "Diet",
                newName: "CalorificValue");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DaysofDiet",
                newName: "ExerciseId");

            migrationBuilder.RenameColumn(
                name: "TreningId",
                table: "DaysofDiet",
                newName: "Day");
        }
    }
}
