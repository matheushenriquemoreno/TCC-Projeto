using FechamentoPedido.DTOS.Carinho;
using FechamentoPedido.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FechamentoPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController(IServiceCarinho serviceCarinho) : ControllerBase
    {
        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarItemCarinho(ItemCarinhoDTO item)
        {
            await serviceCarinho.AdicionarItemCarinho(item);

            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }

        [HttpPost("Diminuir")]
        public async Task<IActionResult> DiminuirItemCarinho(ItemCarinhoDTO item)
        {
            await serviceCarinho.DiminuirItemCarinho(item);

            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }

        [HttpPost("Remover")]
        public async Task<IActionResult> RemoverItemCarinho(ItemCarinhoDTO item)
        {
            await serviceCarinho.RemoverItemCarinho(item);

            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarinho()
        {
            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }
    }
}
