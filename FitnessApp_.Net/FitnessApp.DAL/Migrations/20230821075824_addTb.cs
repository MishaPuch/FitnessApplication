using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeOfMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMucleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfMuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfMeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFoodType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfMeal", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfMuscleGroups");

            migrationBuilder.DropTable(
                name: "TypesOfMeal");
        }
    }
}
