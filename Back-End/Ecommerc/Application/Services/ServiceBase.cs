using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entites.Base;
using Domain.Entites.Paginacao;
using Domain.Interfaces;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class ServiceBase<TEntity, TInput, TOutPut, IRepository>: IServiceBase<TEntity, TInput, TOutPut, IRepository>
        where TEntity : EntityBase
        where TInput : IInputEntity<TEntity>
        where TOutPut : IOutPutEntity<TEntity>
        where IRepository : IRepositoryBase<TEntity>
    {
        private readonly IRepository _repository;
        private readonly IMapper mapper;

        public ServiceBase(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public virtual async Task Adicionar(TInput entity)
        {
            var entidade = mapper.Map<TInput, TEntity>(entity);

            await _repository.Adicionar(entidade);
        }

        public virtual async Task Atualizar(TInput entity)
        {
            var entidade = await _repository.ObterPorIdAsync(entity.Id ?? 0);

            if (entidade is null)
            {
                throw new Exception("Registro não encontrado");
            }

            var entidadeUpdate = mapper.Map<TInput, TEntity>(entity);

            await _repository.Atualizar(entidadeUpdate);
        }

        public virtual async Task<TOutPut> ObterPeloId(int id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);

            return mapper.Map<TEntity, TOutPut>(entidade);
        }

        public virtual async Task<PaginacaoDados<TOutPut>> ObterPaginadosAsync(Paginacao pagiancao)
        {
            var dados = await _repository.ObterTodosPaginadosAsync(pagiancao);

            var paginacao = new PaginacaoDados<TOutPut>(mapper.Map<IEnumerable<TEntity>, IEnumerable<TOutPut>>(dados.DadosPaginados)
                , dados.QuantidadePaginas, dados.QuantidadeRegistros);

            return paginacao;
        }

        public  async Task<IEnumerable<TOutPut>> ObterTodos()
        {
            var dados = await _repository.ObterTodosAsync();

            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TOutPut>>(dados);
        }

        public virtual async Task Remover(int id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);

            if(entidade is null)
            {
                throw new Exception("Registro não encontrado");
            }

            await _repository.Remover(entidade);
        }
    }
}
