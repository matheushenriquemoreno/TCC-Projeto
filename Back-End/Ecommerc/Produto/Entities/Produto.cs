using Domain.Entites.Base;

namespace Produto.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque, List<Imagem> imagens, int idCategoria)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Imagens = imagens;
            IdCategoria = idCategoria;
        }
    }
}
