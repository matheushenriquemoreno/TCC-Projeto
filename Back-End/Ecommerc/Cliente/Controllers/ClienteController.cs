using Cliente.DTO;
using Cliente.DTO.ClienteDTO;
using Cliente.Repository.Interfaces;
using Cliente.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApiHelppers.Controllers;

namespace Cliente.Controllers
{
    public class ClienteController : 
        BaseController<IClienteService, Entities.Cliente, ClienteInput, ClienteOutPut, IClienteRepository>
    {
        public ClienteController(IClienteService service) : base(service)
        {
        }

        [HttpPost("AdicionarELogar")]
        public async Task<ActionResult<ResultLogin>> AdicionarELogar(ClienteInput input)
        {
            return await _service.AdicionarELogar(input);
        }
    }
}
