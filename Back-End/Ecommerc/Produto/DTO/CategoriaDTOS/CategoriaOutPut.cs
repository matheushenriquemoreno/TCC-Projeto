using Application.Interfaces;
using Mapster;
using Produto.Entities;

namespace Produto.DTOS.Categoria
{
    public class CategoriaOutPut : IOutPutEntity<Entities.Categoria>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }

        public void Mapear()
        {
        }
    }
}
