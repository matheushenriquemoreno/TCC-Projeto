using Domain.Entites.Paginacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produto.DTO.ProdutoDTOS;
using Produto.DTOS.Categoria;
using Produto.Services.Interfaces;

namespace Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCategoria(CategoriaInput categoriaAdd)
        {
            await _service.Adicionar(categoriaAdd);
            return Ok();
        }

        [HttpGet("Id:int")]
        public async Task<IActionResult> ObterPorId(int id) => Ok(await _service.ObterPeloId(id));

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _service.ObterTodos();
            return Ok(categorias);
        }

        [HttpGet("ObterDadosPaginados")]
        public async Task<IActionResult> ObterDadosPaginados([FromQuery] Paginacao paginacao)
        {
            var categorias = await _service.ObterPaginadosAsync(paginacao);
            return Ok(categorias);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria(CategoriaInput categoria)
        {
            await _service.Atualizar(categoria);
            return Ok();
        }

        [HttpDelete("Id:int")]
        public async Task<IActionResult> RemoverCategoria(int id)
        {
            await _service.Remover(id);
            return Ok();
        }
    }
}
