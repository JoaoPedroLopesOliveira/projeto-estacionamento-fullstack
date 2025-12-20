using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class RenameVeiculosPermitidosToQuantidadeVeiculosPermitidosAndAddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VeiculosPermitidos",
                table: "Planos",
                newName: "QuantidadeVeiculosPermitidos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Planos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Planos");

            migrationBuilder.RenameColumn(
                name: "QuantidadeVeiculosPermitidos",
                table: "Planos",
                newName: "VeiculosPermitidos");
        }
    }
}
