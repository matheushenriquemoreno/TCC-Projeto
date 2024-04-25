using FechamentoPedido.DTOS.Produto;
using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using FechamentoPedido.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace FechamentoPedido.Services.Implementacoes
{
    public class ServicoProduto(IRepositoryProdutoCarinho repositoryProdutoCarinho) : IServiceProduto
    {
        private string _urlApiProduto = "https://localhost:7017/api/Produto";

        public async Task<ProdutoCarinho> AdicionarPedidoViaIntegracao(int idProduto)
        {
            var produtoExisteBase = await repositoryProdutoCarinho.ObterOnde(x => x.IdProduto == idProduto) is ProdutoCarinho;

            if (produtoExisteBase)
                return await AtualizarPedidoViaIntegracao(idProduto);

            var produto = await $"{_urlApiProduto}"
                .SetQueryParams(new { id = idProduto })
                .GetJsonAsync<ProdutoDTO>();

            var produtoCarinho = new ProdutoCarinho();

            produtoCarinho.Preco = produto.Preco;
            produtoCarinho.Nome = produto.Nome;
            produtoCarinho.Descricao = produto.Descricao;
            produtoCarinho.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoCarinho.UrlImagePrincipal = produto.UrlImagens.FirstOrDefault();
            produtoCarinho.IdProduto = produto.Id;

            await repositoryProdutoCarinho.Adicionar(produtoCarinho);
            return produtoCarinho;
        }

        public async Task<ProdutoCarinho> AtualizarPedidoViaIntegracao(int idProduto)
        {
            var produto = await $"{_urlApiProduto}"
                        .SetQueryParams(new { id = idProduto })
                        .GetJsonAsync<ProdutoDTO>();

            var produtoCarinho = await repositoryProdutoCarinho.ObterOnde(x => x.IdProduto == produto.Id);

            produtoCarinho.Preco = produto.Preco;
            produtoCarinho.Nome = produto.Nome;
            produtoCarinho.Descricao = produto.Descricao;
            produtoCarinho.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoCarinho.UrlImagePrincipal = produto.UrlImagens.FirstOrDefault();

            await repositoryProdutoCarinho.Atualizar(produtoCarinho);

            return produtoCarinho;
        }
    }
}
