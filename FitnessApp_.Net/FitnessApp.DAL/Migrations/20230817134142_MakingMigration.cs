using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars");

            migrationBuilder.RenameTable(
                name: "Calendars",
                newName: "DaysofDiet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaysofDiet",
                table: "DaysofDiet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CalorificCoefficientValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalorificValue = table.Column<double>(type: "float", nullable: false),
                    CalorificCoefficient = table.Column<double>(type: "float", nullable: false),
                    TypeOfMeal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalorificCoefficientValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Carbon = table.Column<double>(type: "float", nullable: false),
                    CalorificOfMeal = table.Column<int>(type: "int", nullable: false),
                    TypeOfMeal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalorificCoefficientValues");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaysofDiet",
                table: "DaysofDiet");

            migrationBuilder.RenameTable(
                name: "DaysofDiet",
                newName: "Calendars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars",
                column: "Id");
        }
    }
}
