using Cliente.DTO;
using Cliente.DTO.ClienteDTO;
using Cliente.DTO.Login;
using Cliente.Repository.Interfaces;
using Cliente.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiHelppers.Controllers;

namespace Cliente.Controllers;

public class ClienteController :
    BaseController<IClienteService, Entities.Cliente, ClienteCreate, ClienteOutPut, IClienteRepository>
{
    public ClienteController(IClienteService service) : base(service)
    {
    }

    [HttpPost("GerenciarEndereco")]
    [Authorize]
    public async Task<IActionResult> GerenciarEndereco([FromBody] EnderecoDTO input)
    {
        await _service.GerenciarEndereco(input);
        return Ok();
    }

    [HttpPost("AdicionarELogar")]
    [AllowAnonymous]
    public async Task<ActionResult<ResultLogin>> AdicionarELogar([FromBody] ClienteCreate input)
    {
        return Ok(await _service.AdicionarELogar(input));
    }

    [HttpPost("LogarCliente")]
    [AllowAnonymous]
    public async Task<ActionResult<ResultLogin>> Logar([FromBody] LoginDTO login)
    {
        return Ok(await _service.LogarCliente(login));
    }
}
