using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
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
                    NameMuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TypesOfTrening",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfTreningValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfTrening", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RestTime = table.Column<int>(type: "int", nullable: false),
                    CalorificValue = table.Column<int>(type: "int", nullable: false),
                    DateOFLastPayment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalorificCoefficientValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalorificValue = table.Column<double>(type: "float", nullable: false),
                    CalorificCoefficient = table.Column<double>(type: "float", nullable: false),
                    TypeOfMealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalorificCoefficientValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalorificCoefficientValues_TypesOfMeal_TypeOfMealId",
                        column: x => x.TypeOfMealId,
                        principalTable: "TypesOfMeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CalorificOfMeal = table.Column<double>(type: "float", nullable: false),
                    TypeOfMealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_TypesOfMeal_TypeOfMealId",
                        column: x => x.TypeOfMealId,
                        principalTable: "TypesOfMeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    TypeOfTreningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_TypeOfMuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "TypeOfMuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_TypesOfTrening_TypeOfTreningId",
                        column: x => x.TypeOfTreningId,
                        principalTable: "TypesOfTrening",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAndDietSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    Times = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAndDietSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingAndDietSchedule_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    TrainingAndDietScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diet_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diet_TrainingAndDietSchedule_TrainingAndDietScheduleId",
                        column: x => x.TrainingAndDietScheduleId,
                        principalTable: "TrainingAndDietSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    TrainingAndDietSchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trenings_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trenings_TrainingAndDietSchedule_TrainingAndDietSchedulesId",
                        column: x => x.TrainingAndDietSchedulesId,
                        principalTable: "TrainingAndDietSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trenings_TypeOfMuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "TypeOfMuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalorificCoefficientValues_TypeOfMealId",
                table: "CalorificCoefficientValues",
                column: "TypeOfMealId");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_MealId",
                table: "Diet",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_TrainingAndDietScheduleId",
                table: "Diet",
                column: "TrainingAndDietScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TypeOfTreningId",
                table: "Exercises",
                column: "TypeOfTreningId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TypeOfMealId",
                table: "Meals",
                column: "TypeOfMealId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAndDietSchedule_UserId",
                table: "TrainingAndDietSchedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trenings_ExerciseId",
                table: "Trenings",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trenings_MuscleGroupId",
                table: "Trenings",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Trenings_TrainingAndDietSchedulesId",
                table: "Trenings",
                column: "TrainingAndDietSchedulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalorificCoefficientValues");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Trenings");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrainingAndDietSchedule");

            migrationBuilder.DropTable(
                name: "TypesOfMeal");

            migrationBuilder.DropTable(
                name: "TypeOfMuscleGroups");

            migrationBuilder.DropTable(
                name: "TypesOfTrening");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
