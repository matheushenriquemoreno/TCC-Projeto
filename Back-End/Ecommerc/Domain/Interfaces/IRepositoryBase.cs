using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites.Base;
using Domain.Entites.Paginacao;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<PaginacaoDados<T>> ObterTodosPaginadosAsync(Paginacao pagiancao);
        Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> expression);
        Task<T> ObterPorIdAsync(int id);
        Task<T> Adicionar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Remover(T entidade);
    }
}
