namespace FechamentoPedido.Services.Interfaces
{
    public interface IServiceIntegracaoProdutos
    {
        Task GerenciarProdutosAtualizados();
        Task GerenciarProdutosAdicionados();
        Task GerenciarProdutosRemovidos();
    }
}
