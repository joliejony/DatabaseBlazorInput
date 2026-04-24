using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatbaseBlazData_.Migrations
{
    /// <inheritdoc />
    public partial class ExcelRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcelRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelRows", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelRows");
        }
    }
}
