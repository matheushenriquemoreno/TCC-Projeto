using Domain.Entites.Base;

namespace Produto.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }
        public string Icone { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            
        }

    }
}
