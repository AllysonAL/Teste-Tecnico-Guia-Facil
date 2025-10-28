namespace TesteTecnico.API.Request
{
    public record EmpresaRequestEdit(int Id, string Nome, string Cnpj, string Email, string Telefone, string Endereco);
}