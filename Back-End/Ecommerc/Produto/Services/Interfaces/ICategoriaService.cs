using Application.Interfaces;
using Produto.DTOS.Categoria;
using Produto.Entities;
using Produto.Repository.Interfaces;

namespace Produto.Services.Interfaces
{
    public interface ICategoriaService : IServiceBase
        <Categoria,
        CategoriaInput,
        CategoriaOutPut,
        ICategoriaRepository>
    {
    }
}
