using Application.Interfaces;
using Domain.Entites.Base;
using Domain.Entites.Paginacao;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiHelppers.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<IService, TEntity, TInput, TOutPut, IRepository> : ControllerBase
        where TEntity : EntityBase
        where TInput : IInputEntity<TEntity>
        where TOutPut : IOutPutEntity<TEntity>
        where IRepository : IRepositoryBase<TEntity>
        where IService : IServiceBase<TEntity, TInput, TOutPut, IRepository>
    {
        protected readonly IService _service;

        public BaseController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody]TInput entity)
        {
            await _service.Adicionar(entity);
            return Ok();
        }

        [HttpGet("ObterDadosPaginados")]
        public async Task<IActionResult> ObterDadosPaginados([FromQuery] Paginacao paginacao)
        {
            var categorias = await _service.ObterPaginadosAsync(paginacao);
            return Ok(categorias);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorId(int id) => Ok(await _service.ObterPeloId(id));

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] TInput entity)
        {
            await _service.Atualizar(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.Remover(id);
            return Ok();
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos() => Ok(await _service.ObterTodos());
    }
}
