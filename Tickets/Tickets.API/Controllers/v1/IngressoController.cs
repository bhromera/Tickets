using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;

namespace Tickets.API.Controllers.v1
{
    [Authorize]
    [Route("/v1/[controller]")]
    public class IngressoController : ControllerBase
    {
        private readonly IIngressoServices _ingressoService;

        public IngressoController(IIngressoServices ingressoService)
        {
            _ingressoService = ingressoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            return await _ingressoService.GetAsync(id);
        }

        [HttpGet("Evento")]
        public async Task<ActionResult> GetByEvento([FromQuery] int idEvento)
        {
            return await _ingressoService.GetByEventoAsync(idEvento);
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> Post([FromBody] Ingresso ingresso)
        {
            return await _ingressoService.CreateAsync(ingresso);
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            return await _ingressoService.DeleteAsync(id);
        }
    }
}
