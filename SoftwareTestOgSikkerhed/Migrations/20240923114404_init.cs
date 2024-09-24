using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareTestOgSikkerhed.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cprs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CprId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cprs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todolist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CprId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todolist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todolist_Cprs_CprId",
                        column: x => x.CprId,
                        principalTable: "Cprs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_CprId",
                table: "Todolist",
                column: "CprId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todolist");

            migrationBuilder.DropTable(
                name: "Cprs");
        }
    }
}
