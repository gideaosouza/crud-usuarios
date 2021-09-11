using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao", "Habilitado" },
                values: new object[] { 1, "Ensino Fundamental", true });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao", "Habilitado" },
                values: new object[] { 2, "Ensino Médio", true });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao", "Habilitado" },
                values: new object[] { 3, "Ensino Superior", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Escolaridades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Escolaridades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Escolaridades",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
