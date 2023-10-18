using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class revertContextToAtributesRoleAndTrening : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleID",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleID",
                table: "Roles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID");
        }
    }
}
