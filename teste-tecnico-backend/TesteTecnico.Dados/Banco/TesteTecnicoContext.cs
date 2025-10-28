using System;
using TesteTecnico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace TesteTecnico.Dados.Banco
{
    public class TesteTecnicoContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }

        public TesteTecnicoContext(DbContextOptions<TesteTecnicoContext> config) : base(config) { }
    }
}
