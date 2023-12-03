using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoDaForca.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretWord = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Attempts = table.Column<int>(type: "INTEGER", nullable: false),
                    Done = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoveryChars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForcaId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoveryChars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoveryChars_Forcas_ForcaId",
                        column: x => x.ForcaId,
                        principalTable: "Forcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscoveryChars_ForcaId",
                table: "DiscoveryChars",
                column: "ForcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoveryChars");

            migrationBuilder.DropTable(
                name: "Forcas");
        }
    }
}
