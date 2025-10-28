using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnico.Dados.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var tabela = "Empresas";
            var campos = new string[] { "Nome", "Cnpj", "Email", "Telefone", "Endereco" };

            migrationBuilder
                .InsertData(tabela, campos,
                    new object[] { "Empresa A", "00.000.000/0000-00", "empresaa@gmail.com", "(00) 99999-9999", "Rua Bonita, 355" });

            migrationBuilder
                .InsertData(tabela, campos,
                    new object[] { "Empresa B", "11.111.111/1111-11", "empresab@gmail.com", "(00) 88888-8888", "Rua das Flores, 103" });

            migrationBuilder
                .InsertData(tabela, campos,
                    new object[] { "Empresa C", "22.222.222/2222-22", "empresac@gmail.com", "(00) 77777-7777", "Rua Jardim Grande, 444" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Empresas");
        }
    }
}
