using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareTestOgSikkerhed.Migrations
{
    /// <inheritdoc />
    public partial class todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Cprs_CprId",
                table: "Todolist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cprs",
                table: "Cprs");

            migrationBuilder.RenameTable(
                name: "Cprs",
                newName: "Cpr");

            migrationBuilder.RenameColumn(
                name: "CprId",
                table: "Cpr",
                newName: "CprNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cpr",
                table: "Cpr",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Cpr_CprId",
                table: "Todolist",
                column: "CprId",
                principalTable: "Cpr",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Cpr_CprId",
                table: "Todolist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cpr",
                table: "Cpr");

            migrationBuilder.RenameTable(
                name: "Cpr",
                newName: "Cprs");

            migrationBuilder.RenameColumn(
                name: "CprNumber",
                table: "Cprs",
                newName: "CprId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cprs",
                table: "Cprs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Cprs_CprId",
                table: "Todolist",
                column: "CprId",
                principalTable: "Cprs",
                principalColumn: "Id");
        }
    }
}
