using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Carrinho;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;

namespace Tickets.API.Controllers.v1
{
    [Authorize]
    [Route("/v1/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoServices _carrinhoServices;

        public CarrinhoController(ICarrinhoServices carrinhoServices)
        {
            _carrinhoServices = carrinhoServices;
        }

        [HttpGet]        
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var user = User.Identity.Name;
            return await _carrinhoServices.GetAsync(id);
        }

        [HttpGet("Cliente")]        
        public async Task<ActionResult> GetByCliente([FromQuery] int id)
        {
            var user = User.Identity.Name;
            return await _carrinhoServices.GetByClienteAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostCarrinhoRequest request)
        {
            return await _carrinhoServices.CreateAsync(request);
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            return await _carrinhoServices.DeleteAsync(id);
        }
    }
}
