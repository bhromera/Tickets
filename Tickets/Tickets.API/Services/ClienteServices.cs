using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ActionResult> CreateAsync(Cliente cliente)
        {
            var response = _clienteRepository.InsertOrUpdate(cliente);

            if (response == null)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = _clienteRepository.Delete(id);

            if (response == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
                return new BadRequestResult();

            return new OkObjectResult(cliente);
        }
    }
}
