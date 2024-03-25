using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class ProdutoCarinho : EntityBase
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string urlImagePrincipal { get; set; }
    }
}
