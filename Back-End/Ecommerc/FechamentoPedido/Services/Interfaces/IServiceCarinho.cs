using FechamentoPedido.DTOS.Carinho;
using FechamentoPedido.Entities.Carrinho;

namespace FechamentoPedido.Services.Interfaces
{
    public interface IServiceCarinho
    {
        Task AdicionarItemCarinho(ItemCarinhoDTO item);
        Task<CarinhoOutPut> ObterCarinhoDoUsuarioLogado();
    }
}
