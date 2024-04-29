using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Juliet.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BostadKategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BildURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BostadKategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kommuner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommuner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mäklarbyråer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logotyp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mäklarbyråer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mäklare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epostadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BildURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MäklarbyråId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mäklare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mäklare_Mäklarbyråer_MäklarbyråId",
                        column: x => x.MäklarbyråId,
                        principalTable: "Mäklarbyråer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bostäder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utgångspris = table.Column<int>(type: "int", nullable: false),
                    Boarea = table.Column<int>(type: "int", nullable: false),
                    Biarea = table.Column<int>(type: "int", nullable: false),
                    Tomtarea = table.Column<int>(type: "int", nullable: false),
                    Antalrum = table.Column<int>(type: "int", nullable: false),
                    Månadsavgift = table.Column<int>(type: "int", nullable: false),
                    Driftkonstnad = table.Column<int>(type: "int", nullable: false),
                    Byggår = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Objektbeskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    KommunId = table.Column<int>(type: "int", nullable: false),
                    MäklareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bostäder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bostäder_BostadKategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "BostadKategorier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bostäder_Kommuner_KommunId",
                        column: x => x.KommunId,
                        principalTable: "Kommuner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bostäder_Mäklare_MäklareId",
                        column: x => x.MäklareId,
                        principalTable: "Mäklare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BostadsBilder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BildURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BostadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BostadsBilder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BostadsBilder_Bostäder_BostadId",
                        column: x => x.BostadId,
                        principalTable: "Bostäder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_KategoriId",
                table: "Bostäder",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_KommunId",
                table: "Bostäder",
                column: "KommunId");

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_MäklareId",
                table: "Bostäder",
                column: "MäklareId");

            migrationBuilder.CreateIndex(
                name: "IX_BostadsBilder_BostadId",
                table: "BostadsBilder",
                column: "BostadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mäklare_MäklarbyråId",
                table: "Mäklare",
                column: "MäklarbyråId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BostadsBilder");

            migrationBuilder.DropTable(
                name: "Bostäder");

            migrationBuilder.DropTable(
                name: "BostadKategorier");

            migrationBuilder.DropTable(
                name: "Kommuner");

            migrationBuilder.DropTable(
                name: "Mäklare");

            migrationBuilder.DropTable(
                name: "Mäklarbyråer");
        }
    }
}
