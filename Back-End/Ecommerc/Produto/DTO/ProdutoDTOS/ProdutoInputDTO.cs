using Application.Interfaces;
using Mapster;
using Produto.Entities;

namespace Produto.DTO.ProdutoDTOS
{
    public class ProdutoInputDTO : IInputEntity<Entities.Produto>
    {
        public int? Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public List<string> UrlImagens { get; set; } = new List<string>();
  
        public void Mapear()
        {
                TypeAdapterConfig<ProdutoInputDTO, Entities.Produto>.NewConfig()
                .BeforeMapping((a,b) =>
                {
                    b.Imagens = a.UrlImagens.Select(x => new Imagem() { Url = x, Produto = b }).ToList();
                });
        }
    }
}
