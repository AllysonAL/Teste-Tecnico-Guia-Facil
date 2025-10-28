using System;
using TesteTecnico.Dados.Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace TesteTecnico.Dados.Infraestrutura
{
    internal class TesteTecnicoContextFactory : IDesignTimeDbContextFactory<TesteTecnicoContext>
    {
        public TesteTecnicoContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<TesteTecnicoContextFactory>()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TesteTecnicoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TesteTecnicoContext(optionsBuilder.Options);
        }
    }
}