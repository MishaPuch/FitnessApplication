using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixTrainingAndDietSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayId",
                table: "TrainingAndDietSchedule");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "TrainingAndDietSchedule");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "TrainingAndDietSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "TrainingAndDietSchedule");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "TrainingAndDietSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "TrainingAndDietSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
