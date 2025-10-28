using System;

namespace TesteTecnico.Modelos
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Empresa(string nome, string cnpj, string email, string telefone, string endereco)
        {
            Nome = nome;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}