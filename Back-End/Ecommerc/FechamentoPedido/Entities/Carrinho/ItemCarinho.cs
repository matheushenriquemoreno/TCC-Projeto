using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class ItemCarinho : EntityBase
    {
        public CarinhoCompra Carinho { get; set; }
        public int IdProduto { get; set; }
        public ProdutoCarinho Produto { get; set; }
        public int Quantidade { get; set; }

        public decimal Valortotal
        {
            get
            {
                return Quantidade * Produto.Preco;
            }
        }

        public ItemCarinho()
        {
            
        }

        public ItemCarinho(CarinhoCompra carinho, int idProduto, int quantidade)
        {
            Carinho = carinho;
            IdProduto = idProduto;
            Quantidade = quantidade;
        }
    }
}
