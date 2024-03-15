using Domain.Entites.Base;

namespace Produto.Entities
{
    public class Imagem : EntityBase
    {
        public string Url { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
