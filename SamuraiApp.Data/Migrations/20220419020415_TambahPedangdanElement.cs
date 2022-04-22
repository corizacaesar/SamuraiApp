using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class TambahPedangdanElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TahunPembuatan = table.Column<int>(type: "int", nullable: false),
                    Berat = table.Column<int>(type: "int", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedangs_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementPedang",
                columns: table => new
                {
                    ElementsId = table.Column<int>(type: "int", nullable: false),
                    PedangsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPedang", x => new { x.ElementsId, x.PedangsId });
                    table.ForeignKey(
                        name: "FK_ElementPedang_Elements_ElementsId",
                        column: x => x.ElementsId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPedang_Pedangs_PedangsId",
                        column: x => x.PedangsId,
                        principalTable: "Pedangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementPedang_PedangsId",
                table: "ElementPedang",
                column: "PedangsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedangs_SamuraiId",
                table: "Pedangs",
                column: "SamuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementPedang");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Pedangs");
        }
    }
}
