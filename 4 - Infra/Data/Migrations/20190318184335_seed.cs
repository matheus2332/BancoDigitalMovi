using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "LimiteDeEmprestimo", "Nome", "Senha", "Usuario" },
                values: new object[] { new Guid("f492c222-4b54-4937-93b6-6cbd4b939a41"), "40426235819", 1000m, "Usuario movidesk", "21232f297a57a5a743894a0e4a801fc3", "movidesk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: new Guid("f492c222-4b54-4937-93b6-6cbd4b939a41"));
        }
    }
}
