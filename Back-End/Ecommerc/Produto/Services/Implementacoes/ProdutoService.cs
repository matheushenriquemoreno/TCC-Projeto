using Application.Services;
using MapsterMapper;
using Produto.DTO.ProdutoDTOS;
using Produto.Repository.Interfaces;
using Produto.Services.Interfaces;

namespace Produto.Services.Implementacoes;

public class ProdutoService : ServiceBase<Entities.Produto, ProdutoInputDTO, ProdutoOutPutDTO, IRepositoryProduto>, IProdutoService
{
    public ProdutoService(IRepositoryProduto repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
