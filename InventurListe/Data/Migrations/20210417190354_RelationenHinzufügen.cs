using Microsoft.EntityFrameworkCore.Migrations;

namespace InventurListe.Data.Migrations
{
    public partial class RelationenHinzufügen : Migration
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

            migrationBuilder.CreateTable(
                name: "Haus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandortId = table.Column<int>(type: "int", nullable: false),
                    RaumId = table.Column<int>(type: "int", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    HausName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockwerkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haus_Raum_RaumId",
                        column: x => x.RaumId,
                        principalTable: "Raum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Haus_Standort_StandortId",
                        column: x => x.StandortId,
                        principalTable: "Standort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Haus_Stockwerk_StockwerkId",
                        column: x => x.StockwerkId,
                        principalTable: "Stockwerk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gerät",
                columns: table => new
                {
                    InventurNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeräteTypId = table.Column<int>(type: "int", nullable: false),
                    HausId = table.Column<int>(type: "int", nullable: false),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BetriebssystemId = table.Column<int>(type: "int", nullable: false),
                    VianovaNr = table.Column<int>(type: "int", nullable: false),
                    AbteilungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerät", x => x.InventurNr);
                    table.ForeignKey(
                        name: "FK_Gerät_Abteilung_AbteilungId",
                        column: x => x.AbteilungId,
                        principalTable: "Abteilung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gerät_Betriebssystem_BetriebssystemId",
                        column: x => x.BetriebssystemId,
                        principalTable: "Betriebssystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gerät_GeräteTyp_GeräteTypId",
                        column: x => x.GeräteTypId,
                        principalTable: "GeräteTyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gerät_Haus_HausId",
                        column: x => x.HausId,
                        principalTable: "Haus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gerät_AbteilungId",
                table: "Gerät",
                column: "AbteilungId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerät_BetriebssystemId",
                table: "Gerät",
                column: "BetriebssystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerät_GeräteTypId",
                table: "Gerät",
                column: "GeräteTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerät_HausId",
                table: "Gerät",
                column: "HausId");

            migrationBuilder.CreateIndex(
                name: "IX_Haus_RaumId",
                table: "Haus",
                column: "RaumId");

            migrationBuilder.CreateIndex(
                name: "IX_Haus_StandortId",
                table: "Haus",
                column: "StandortId");

            migrationBuilder.CreateIndex(
                name: "IX_Haus_StockwerkId",
                table: "Haus",
                column: "StockwerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gerät");

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
