using FechamentoPedido.Entities.Carrinho;

namespace FechamentoPedido.DTOS.Carinho
{
    public class CarinhoOutPut
    {
        public List<ItemCarinhoOutPut> Produtos { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return Produtos.Sum(x => x.ProdutoCarinho.Preco * x.Quantidade);
            }
        }
    }

    public class ItemCarinhoOutPut
    {
        public int Quantidade { get; set; }
        public ProdutoCarinhoOutPut ProdutoCarinho { get; set; }
    }


    public class ProdutoCarinhoOutPut
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string UrlImagePrincipal { get; set; }
    }
}
