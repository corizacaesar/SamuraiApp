using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class newRelationDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedangs_Samurais_SamuraiId",
                table: "Pedangs");

            migrationBuilder.DropTable(
                name: "ElementPedang");

            migrationBuilder.AlterColumn<int>(
                name: "TahunPembuatan",
                table: "Pedangs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Pedangs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "Pedangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Berat",
                table: "Pedangs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PedangId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_PedangId",
                table: "Elements",
                column: "PedangId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Pedangs_PedangId",
                table: "Elements",
                column: "PedangId",
                principalTable: "Pedangs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedangs_Samurais_SamuraiId",
                table: "Pedangs",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Pedangs_PedangId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedangs_Samurais_SamuraiId",
                table: "Pedangs");

            migrationBuilder.DropIndex(
                name: "IX_Elements_PedangId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "PedangId",
                table: "Elements");

            migrationBuilder.AlterColumn<int>(
                name: "TahunPembuatan",
                table: "Pedangs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Pedangs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "Pedangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Berat",
                table: "Pedangs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedangs_Samurais_SamuraiId",
                table: "Pedangs",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
