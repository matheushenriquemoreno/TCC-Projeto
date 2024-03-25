using Application.Interfaces;
using Mapster;

namespace Produto.DTO.ProdutoDTOS
{
    public class ProdutoOutPutDTO : ProdutoInputDTO, IOutPutEntity<Entities.Produto>
    {
        public void Mapear()
        {
            TypeAdapterConfig<Entities.Produto, ProdutoOutPutDTO>.NewConfig()
                     .BeforeMapping((a, b) =>
                     {
                         b.UrlImagens = a.Imagens.Select(x => x.Url).ToList();
                     });
        }
    }
}
