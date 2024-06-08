namespace Produto.Services.Interfaces
{
    public interface IServiceFilaProduto
    {
        Task AdicionarProdutoCriadoNaFila(Entities.Produto produto);
        Task AdicionarProdutoAtualizadoNaFila(Entities.Produto produto);
        Task AdicionarProdutoRemovidoFila(int idProduto);
    }
}
