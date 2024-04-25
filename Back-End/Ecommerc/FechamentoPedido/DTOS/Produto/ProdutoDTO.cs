namespace FechamentoPedido.DTOS.Produto
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public List<string> UrlImagens { get; set; } = new List<string>();
    }
}
