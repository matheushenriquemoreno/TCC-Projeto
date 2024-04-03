using Cliente.DTO;
using Cliente.DTO.ClienteDTO;
using Cliente.DTO.Login;
using Cliente.Repository.Interfaces;
using Cliente.Services.Interfaces;
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
    public async Task<IActionResult> GerenciarEndereco([FromBody] EnderecoDTO input)
    {
        await _service.GerenciarEndereco(input);
        return Ok();
    }

    [HttpPost("AdicionarELogar")]
    public async Task<ActionResult<ResultLogin>> AdicionarELogar([FromBody] ClienteCreate input)
    {
        return Ok(await _service.AdicionarELogar(input));
    }

    [HttpPost("LogarCliente")]
    public async Task<ActionResult<ResultLogin>> Logar([FromBody] LoginDTO login)
    {
        return Ok(await _service.LogarCliente(login));
    }
}
