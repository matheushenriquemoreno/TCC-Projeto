namespace Produto.Services.Interfaces
{
    public interface IServiceFilaProduto
    {
        Task AdicionarMensagemDeCriacao(Entities.Produto produto);
        Task AdicionarMensagemDeAtualizacao(Entities.Produto produto);
        Task AdicionarMensagemRemocao(int idProduto);
    }
}
