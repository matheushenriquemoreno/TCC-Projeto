using Application.Interfaces;

namespace Produto.DTOS.Categoria
{
    public class CategoriaInput : IInputEntity<Entities.Categoria>
    {
        public string Nome { get; set; }
        public string Icone { get; set; }
        public int? Id { get; set; }

        public void Mapear()
        {
        }
    }
}
