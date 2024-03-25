using FechamentoPedido.Entities.Carrinho;

namespace FechamentoPedido.Services.Interfaces
{
    public interface IServiceCarinho
    {
        void AtualizarCarinho(int idCliente, List<ItemCarinho> Produtos);
    }
}
