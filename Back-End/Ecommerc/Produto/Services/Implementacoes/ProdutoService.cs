using System.Collections.Generic;
using Application.Services;
using MapsterMapper;
using Produto.DTO.ProdutoDTOS;
using Produto.Repository.Interfaces;
using Produto.Services.Interfaces;

namespace Produto.Services.Implementacoes;

public class ProdutoService : ServiceBase<Entities.Produto, ProdutoInputDTO, ProdutoOutPutDTO, IRepositoryProduto>
    , IProdutoService
{
    public ProdutoService(IRepositoryProduto repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<List<ProdutoVenda>> ObterProdutosPorCategoria(int categoriaId)
    {
       var dados = await _repository.ObterTodosOnde(x => x.IdCategoria == categoriaId);

        return mapper.Map<List<ProdutoVenda>>(dados);
    }
}
