using FechamentoPedido.DTOS.Carinho;
using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using FechamentoPedido.Services.Interfaces;

namespace FechamentoPedido.Services.Implementacoes
{
    public class ServiceCarinho(IRepositoryCarinho repositoryCarinho, IRepositoryProdutoCarinho repositoryProdutoCarinho) : IServiceCarinho
    {
        
        public async Task AdicionarItemCarinho(ItemCarinhoDTO item)
        {
            var produto = await repositoryProdutoCarinho.ObterPorIdAsync(item.IdProduto);

            if(produto is null)
            {
                // Chamar o serviço de produto, que vai na api obter o produto e adicionar na base.
            }


            CarinhoCompra carinho = await repositoryCarinho.ObterOnde(x => x.IdCliente == 1);


            if(carinho is null)
            {
               var itens = new List<ItemCarinho> { new ItemCarinho(item.IdProduto, item.Quantidade)  };

                carinho = new CarinhoCompra()
                {
                    IdCliente = 1,
                    Produtos = itens
                };

                await repositoryCarinho.Adicionar(carinho);
            }

            carinho.AumentarQuantidadeProduto(item.IdProduto, item.Quantidade);

            await repositoryCarinho.Atualizar(carinho);
        }
    }
}
