using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TesteTecnico.Dados.Banco
{
    public class DAL<T> where T : class
    {
        private TesteTecnicoContext Context { get; set; }

        public DAL(TesteTecnicoContext context) 
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task AdicionarAsync(T objeto)
        {
            Context.Set<T>().Add(objeto);
            await Context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T objeto)
        {
            Context.Set<T>().Update(objeto);
            await Context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(T objeto)
        {
            Context.Set<T>().Remove(objeto);
            await Context.SaveChangesAsync();
        }

        public async Task<T?> RecuperarItemPorAsync(Expression<Func<T, bool>> condicao)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(condicao);
        }

        public async Task<IEnumerable<T>> RecuperarListaPorAsync(Expression<Func<T, bool>> condicao)
        {
            return await Context.Set<T>().AsNoTracking().Where(condicao).ToListAsync();
        }
    }
}