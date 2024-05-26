using Application.Interfaces;
using Mapster;

namespace Produto.DTO.ProdutoDTOS
{
    public class ProdutoVendaOutPutDTO : IOutPutEntity<Entities.Produto>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public List<string> UrlImagens { get; set; } = new List<string>();

        public void Mapear()
        {
            TypeAdapterConfig<Entities.Produto, ProdutoVendaOutPutDTO>.NewConfig()
                     .BeforeMapping((a, b) =>
                     {
                         b.UrlImagens = a.Imagens.Select(x => x.Url).ToList();
                     });
        }
    }
}
