using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFornecedor.Migrations
{
    public partial class FornecedoresBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forncedores",
                table: "Forncedores");

            migrationBuilder.RenameTable(
                name: "Forncedores",
                newName: "Fornecedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Forncedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forncedores",
                table: "Forncedores",
                column: "Id");
        }
    }
}
