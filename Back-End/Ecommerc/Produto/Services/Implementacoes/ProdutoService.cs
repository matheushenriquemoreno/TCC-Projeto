using System.Collections.Generic;
using Application.Services;
using MapsterMapper;
using Produto.DTO.ProdutoDTOS;
using Produto.Entities;
using Produto.Repository.Interfaces;
using Produto.Services.Interfaces;

namespace Produto.Services.Implementacoes;

public class ProdutoService : ServiceBase<Entities.Produto, ProdutoInputDTO, ProdutoOutPutDTO, IRepositoryProduto>,
    IProdutoService
{

    private readonly IServiceFilaProduto serviceFilaProduto;

    public ProdutoService(IRepositoryProduto repository, IMapper mapper, IServiceFilaProduto serviceFilaProduto) : base(repository, mapper)
    {
        this.serviceFilaProduto = serviceFilaProduto;
    }

    public override async Task<Entities.Produto> Adicionar(ProdutoInputDTO entity)
    {
        var produto = await base.Adicionar(entity);

        await serviceFilaProduto.AdicionarMensagemDeCriacao(produto);

        return produto;
    }

    public override async Task<Entities.Produto> Atualizar(ProdutoInputDTO entity)
    {
        var produto = await base.Atualizar(entity);

        await serviceFilaProduto.AdicionarMensagemDeAtualizacao(produto);

        return produto;
    }

    public override async Task Remover(int id)
    {
        await base.Remover(id);

        await serviceFilaProduto.AdicionarMensagemRemocao(id);
    }

    public async Task<List<ProdutoVendaOutPutDTO>> ObterProdutosPorCategoria(int categoriaId)
    {
        var dados = await _repository.ObterTodosOnde(x => x.IdCategoria == categoriaId);

        return mapper.Map<List<ProdutoVendaOutPutDTO>>(dados.ToList());
    }
}
