using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class AdicionadoRelacionamentoPostagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Postagems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Postagems_UsuarioId",
                table: "Postagems",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagems_Usuarios_UsuarioId",
                table: "Postagems",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagems_Usuarios_UsuarioId",
                table: "Postagems");

            migrationBuilder.DropIndex(
                name: "IX_Postagems_UsuarioId",
                table: "Postagems");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Postagems");
        }
    }
}
