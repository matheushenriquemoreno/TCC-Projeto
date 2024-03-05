
using System;
using Produto.DTOS.Categoria;
using Produto.Repository.Interfaces;
using Produto.Services.Interfaces;
using Produto.Entities;
using Mapster;
using Application.Interfaces;
using Application.Services;
using MapsterMapper;

namespace Produto.Services.Implementacoes
{
    public class CategoriaService : ServiceBase
        <Categoria,
        CategoriaInput,
        CategoriaOutPut,
        ICategoriaRepository>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
