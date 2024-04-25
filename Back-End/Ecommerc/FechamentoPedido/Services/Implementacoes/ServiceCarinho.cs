using FechamentoPedido.DTOS.Carinho;
using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using FechamentoPedido.Services.Interfaces;
using Mapster;

namespace FechamentoPedido.Services.Implementacoes
{
    public class ServiceCarinho(IRepositoryCarinho repositoryCarinho,
        IRepositoryProdutoCarinho repositoryProdutoCarinho,
        IServiceProduto serviceProduto) : IServiceCarinho
    {
        
        public async Task AdicionarItemCarinho(ItemCarinhoDTO item)
        {
            var produto = await repositoryProdutoCarinho.ObterOnde(x => x.IdProduto == item.IdProduto);

            if(produto is null)
            {
                produto = await serviceProduto.AdicionarPedidoViaIntegracao(item.IdProduto);
            }

            CarinhoCompra carinho = await repositoryCarinho.ObterOnde(x => x.IdCliente == 1);

            if(carinho is null)
            {
               var itens = new List<ItemCarinho> { new ItemCarinho(produto.Id, item.Quantidade)  };

                carinho = new CarinhoCompra()
                {
                    IdCliente = 1,
                    Produtos = itens
                };

                await repositoryCarinho.Adicionar(carinho);
                return;
            }

            carinho.AumentarQuantidadeProduto(produto.Id, item.Quantidade);

            await repositoryCarinho.Atualizar(carinho);
        }

        public async Task<CarinhoOutPut> ObterCarinhoDoUsuarioLogado()
        {
            var carinho = await repositoryCarinho.ObterOnde(x => x.IdCliente == 1);

            return new CarinhoOutPut()
            {
                Produtos = carinho.Produtos.Select(x =>
                {
                    return new ItemCarinhoOutPut
                    {
                        Quantidade = x.Quantidade,
                        ProdutoCarinho = x.Produto.Adapt<ProdutoCarinhoOutPut>()
                    };
                }).ToList()
            };
        }
    }
}
