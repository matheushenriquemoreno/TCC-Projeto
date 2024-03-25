using System.Collections.Generic;
using Application.Services;
using MapsterMapper;
using Produto.DTO.ProdutoDTOS;
using Produto.Repository.Interfaces;
using Produto.Services.Interfaces;

namespace Produto.Services.Implementacoes;

public class ProdutoService : ServiceBase<Entities.Produto, ProdutoInputDTO, ProdutoOutPutDTO, IRepositoryProduto>,
    IProdutoService
{
    public ProdutoService(IRepositoryProduto repository, IMapper mapper) : base(repository, mapper)
    {
    }
    public override async Task<Entities.Produto> Adicionar(ProdutoInputDTO entity)
    {
        var produto = await base.Adicionar(entity);

        // Adicionar aqui a chamada para a fila

        return produto;
    }

    public override async Task<Entities.Produto> Atualizar(ProdutoInputDTO entity)
    {
        var produto = await base.Atualizar(entity);

        // Adicionar aqui a chamada para a fila

        return produto;
    }

    public override async Task Remover(int id)
    {
        await base.Remover(id);

        // Adicionar aqui a chamada para a fila
    }

    public async Task<List<ProdutoVenda>> ObterProdutosPorCategoria(int categoriaId)
    {
        var dados = await _repository.ObterTodosOnde(x => x.IdCategoria == categoriaId);

        return mapper.Map<List<ProdutoVenda>>(dados);
    }
}
