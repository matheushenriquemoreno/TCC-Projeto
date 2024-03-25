using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entites.Base;
using Domain.Entites.Paginacao;
using Domain.Interfaces;
using FluentValidation;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class ServiceBase<TEntity, TInput, TOutPut, IRepository> : IServiceBase<TEntity, TInput, TOutPut, IRepository>
        where TEntity : EntityBase
        where TInput : IInputEntity<TEntity>
        where TOutPut : IOutPutEntity<TEntity>
        where IRepository : IRepositoryBase<TEntity>
    {
        protected readonly IRepository _repository;
        protected readonly IMapper mapper;
        protected readonly IValidator<TEntity> _validator;

        public ServiceBase(IRepository repository, IMapper mapper, IValidator<TEntity> validator = null)
        {
            _repository = repository;
            this.mapper = mapper;
            _validator = validator;
        }

        #region Adicionar
        public virtual async Task ValidarAdicionar(TEntity entity)
        {
            if (_validator is not null)
                await _validator.ValidateAndThrowAsync(entity);
        }

        public virtual async Task<TEntity> Adicionar(TInput entity)
        {
            var entidade = mapper.Map<TInput, TEntity>(entity);

            await ValidarAdicionar(entidade);

            await _repository.Adicionar(entidade);

            return entidade;
        }
        #endregion

        #region Atualizar

        public virtual async Task ValidarAtualizar(TEntity entity)
        {
            if (_validator is not null)
                await _validator.ValidateAndThrowAsync(entity);
        }

        public virtual async Task<TEntity> Atualizar(TInput entity)
        {
            var entidade = await _repository.ObterPorIdAsync(entity.Id ?? 0);

            if (entidade is null)
                throw new RegistroNaoEncontradoException();

            var entidadeUpdate = mapper.Map<TInput, TEntity>(entity);

            await ValidarAtualizar(entidadeUpdate);

            return await _repository.Atualizar(entidadeUpdate);
        }

        #endregion

        #region Remover
        public virtual async Task Remover(int id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);

            if (entidade is null)
                throw new RegistroNaoEncontradoException();

            await _repository.Remover(entidade);
        }
        #endregion

        public virtual async Task<TOutPut> ObterPeloId(int id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);

            if (entidade is null)
                throw new RegistroNaoEncontradoException();

            return mapper.Map<TEntity, TOutPut>(entidade);
        }

        public virtual async Task<PaginacaoDados<TOutPut>> ObterPaginadosAsync(Paginacao pagiancao)
        {
            var dados = await _repository.ObterTodosPaginadosAsync(pagiancao);

            var paginacao = new PaginacaoDados<TOutPut>(mapper.Map<IEnumerable<TEntity>, IEnumerable<TOutPut>>(dados.DadosPaginados)
                , dados.QuantidadePaginas, dados.QuantidadeRegistros);

            return paginacao;
        }

        public async Task<IEnumerable<TOutPut>> ObterTodos()
        {
            var dados = await _repository.ObterTodosAsync();

            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TOutPut>>(dados);
        }
    }
}
