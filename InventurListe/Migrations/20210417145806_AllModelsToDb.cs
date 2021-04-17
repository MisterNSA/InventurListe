using Microsoft.EntityFrameworkCore.Migrations;

namespace InventurListe.Migrations
{
    public partial class AllModelsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abteilung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbteilungName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abteilung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Betriebssystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betriebssystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeräteTyp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GerätTyp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeräteTyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Haus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandortId = table.Column<int>(type: "int", nullable: false),
                    HausId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    HausName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaumName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Standort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stockwerk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockwerk", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abteilung");

            migrationBuilder.DropTable(
                name: "Betriebssystem");

            migrationBuilder.DropTable(
                name: "GeräteTyp");

            migrationBuilder.DropTable(
                name: "Haus");

            migrationBuilder.DropTable(
                name: "Raum");

            migrationBuilder.DropTable(
                name: "Standort");

            migrationBuilder.DropTable(
                name: "Stockwerk");
        }
    }
}
