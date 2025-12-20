using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class VeiculoClienteOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Veiculos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
