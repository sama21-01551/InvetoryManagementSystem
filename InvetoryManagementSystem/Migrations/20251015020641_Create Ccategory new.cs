using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvetoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateCcategorynew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ccategories",
                columns: table => new
                {
                    CcategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CcategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CcategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ccategories", x => x.CcategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ccategories");
        }
    }
}
