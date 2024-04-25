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


        [HttpPost]
        public async Task<IActionResult> AdicionarItemCarinho(ItemCarinhoDTO item)
        {
            await serviceCarinho.AdicionarItemCarinho(item);

            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarinho()
        {
            return Ok(await serviceCarinho.ObterCarinhoDoUsuarioLogado());
        }
    }
}
