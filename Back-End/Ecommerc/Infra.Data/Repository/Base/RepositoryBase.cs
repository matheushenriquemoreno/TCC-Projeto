using System.Linq.Expressions;
using Domain.Entites.Base;
using Domain.Entites.Paginacao;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DbContext _context;

        public RepositoryBase(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        protected DbSet<T> Entidade() => _context.Set<T>();

        public virtual async Task<T> ObterPorIdAsync(int id)
        {
            return await Entidade().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> expression)
        {
            var dados = Entidade()
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .Where(expression);

            return Task.FromResult<IEnumerable<T>>(dados);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await Entidade()
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> Adicionar(T entidade)
        {
            await Entidade().AddAsync(entidade);
            await Salvar();
            return entidade;
        }

        public async  Task Remover(T entidade)
        {
            _context.Remove(entidade);
            await Salvar();
        }

        public virtual async Task<T> Atualizar(T entidade)
        {
            Entidade().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            await Salvar();
            return entidade;
        }

        private async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IQueryable<T>> AplicarFiltros(IQueryable<T> dados, Paginacao paginacao)
        {
            return dados;
        }

        public async Task<PaginacaoDados<T>> ObterTodosPaginadosAsync(Paginacao paginacao)
        {
            var dados = Entidade()
               .OrderByDescending(x => x.Id)
               .AsNoTracking();

            dados = await AplicarFiltros(dados, paginacao);

            var quantidadeRegistros = dados.Count();

           var quantidadePaginas = (int)Math.Ceiling((decimal)quantidadeRegistros / paginacao.QuantidadeRegistros);

            var dadosPaginados = dados
               .Skip((paginacao.PaginaAtual - 1) * paginacao.QuantidadeRegistros)
               .Take(paginacao.QuantidadeRegistros);

            return new PaginacaoDados<T>(dadosPaginados,quantidadePaginas, quantidadeRegistros);
        }
    }
}
