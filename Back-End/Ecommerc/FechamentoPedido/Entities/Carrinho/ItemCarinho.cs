using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class ItemCarinho : EntityBase
    {
        public CarinhoCompra Carinho { get; set; }
        public int IdProduto { get; set; }
        public ProdutoCarinho Produto { get; set; }
        public int Quantidade { get; protected set; }

        public void AumentarQuantidade(int quantidade)
        {
            if (quantidade + this.Quantidade > this.Produto.QuantidadeEstoque)
                throw new InvalidOperationException("Quantidade em estoque insuficiente.");
            Quantidade += quantidade;
        }

        public void DiminuirQuantidade(int quantidade)
        {
            if (this.Quantidade - quantidade == 0)
                return;

            this.Quantidade -= quantidade;
        }

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

        public ItemCarinho(int idProduto, int quantidade)
        {
            IdProduto = idProduto;
            Quantidade = quantidade;
        }
    }
}
