using Domain.Entites.Base;
using Domain.Entites.Paginacao;
using Domain.Interfaces;

namespace Application.Interfaces;

public interface IServiceBase<TEntity, TInput, TOutPut, IRepository> 
    where TEntity : EntityBase
    where TInput : IInputEntity<TEntity>
    where TOutPut : IOutPutEntity<TEntity>
    where IRepository : IRepositoryBase<TEntity>
{
    Task<TEntity> Adicionar(TInput entity);
    Task<TEntity> Atualizar(TInput entity);
    Task Remover(int id);
    Task<TOutPut> ObterPeloId(int id);
    Task<IEnumerable<TOutPut>> ObterTodos();
    Task<PaginacaoDados<TOutPut>> ObterPaginadosAsync(Paginacao pagiancao);
}
