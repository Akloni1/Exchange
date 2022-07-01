using Microsoft.EntityFrameworkCore.Migrations;

namespace Exchange.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valute",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCode = table.Column<string>(nullable: true),
                    CharCode = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Nominal = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Previous = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valute", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valute");
        }
    }
}
