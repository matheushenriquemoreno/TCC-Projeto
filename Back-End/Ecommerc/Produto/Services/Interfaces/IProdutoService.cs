using Application.Interfaces;
using Produto.DTO.ProdutoDTOS;
using Produto.Entities;
using Produto.Repository.Interfaces;

namespace Produto.Services.Interfaces
{
    public interface IProdutoService : IServiceBase<
        Entities.Produto, ProdutoInputDTO, ProdutoOutPutDTO, IRepositoryProduto>
    {
    }
}
