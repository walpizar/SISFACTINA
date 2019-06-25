using Microsoft.EntityFrameworkCore.Migrations;

namespace AppFacturadorApi.Data.Migrations
{
    public partial class migra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__tbProvin__75E3EFCF25DA01E3",
                table: "tbProvincia");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "tbSucursales",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbSucursales_provincia_canton_distrito",
                table: "tbSucursales",
                columns: new[] { "provincia", "canton", "distrito" });

            migrationBuilder.CreateIndex(
                name: "UQ__tbProvin__75E3EFCF25DA01E3",
                table: "tbProvincia",
                column: "Nombre",
                unique: true,
                filter: "([Nombre] IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_tbSucursales_tbDistrito",
                table: "tbSucursales",
                columns: new[] { "provincia", "canton", "distrito" },
                principalTable: "tbDistrito",
                principalColumns: new[] { "Provincia", "Canton", "Distrito" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbSucursales_tbDistrito",
                table: "tbSucursales");

            migrationBuilder.DropIndex(
                name: "IX_tbSucursales_provincia_canton_distrito",
                table: "tbSucursales");

            migrationBuilder.DropIndex(
                name: "UQ__tbProvin__75E3EFCF25DA01E3",
                table: "tbProvincia");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "tbSucursales");

            migrationBuilder.CreateIndex(
                name: "UQ__tbProvin__75E3EFCF25DA01E3",
                table: "tbProvincia",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");
        }
    }
}
