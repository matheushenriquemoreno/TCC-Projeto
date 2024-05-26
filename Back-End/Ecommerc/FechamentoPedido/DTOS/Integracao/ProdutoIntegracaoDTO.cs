namespace FechamentoPedido.DTOS.Integracao
{
    public class ProdutoIntegracaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public List<ImagemIntegracaoDTO> Imagens { get; set; } = new List<ImagemIntegracaoDTO>();
        public int IdCategoria { get; set; }
    }

    public class ImagemIntegracaoDTO
    {
        public string Url { get; set; }
        public int IdProduto { get; set; }
    }
}
