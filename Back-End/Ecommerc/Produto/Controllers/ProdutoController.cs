using Domain.Entites.Paginacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produto.DTO.ProdutoDTOS;
using Produto.Services.Interfaces;

namespace Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(ProdutoInputDTO produto)
        {
            await _service.Adicionar(produto);
            return Ok();
        }

        [HttpGet("ObterDadosPaginados")]
        public async Task<IActionResult> ObterDadosPaginados([FromQuery] Paginacao paginacao)
        {
            var categorias = await _service.ObterPaginadosAsync(paginacao);
            return Ok(categorias);
        }

        [HttpGet("Id:int")]
        public async Task<IActionResult> ObterPorId(int id) => Ok(await _service.ObterPeloId(id));

        [HttpPut]
        public async Task<IActionResult> AtualizarProduto(ProdutoInputDTO produto)
        {
            await _service.Atualizar(produto);
            return Ok();
        }

        [HttpDelete("Id:int")]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            await _service.Remover(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos() => Ok(await _service.ObterTodos());
    }
}
