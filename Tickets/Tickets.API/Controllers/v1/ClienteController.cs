using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;

namespace Tickets.API.Controllers.v1
{
    [Authorize]
    [Route("/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteService;

        public ClienteController(IClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]        
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var user = User.Identity.Name;
            return await _clienteService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            return await _clienteService.CreateAsync(cliente);
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            return await _clienteService.DeleteAsync(id);
        }
    }
}
