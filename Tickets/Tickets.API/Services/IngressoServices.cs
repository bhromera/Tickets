using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Services
{
    public class IngressoServices : IIngressoServices
    {
        private readonly IIngressoRepository _ingressoRepository;

        public IngressoServices(IIngressoRepository ingressoRepository)
        {
            _ingressoRepository = ingressoRepository;
        }

        public async Task<ActionResult> CreateAsync(Ingresso ingresso)
        {
            var response = _ingressoRepository.InsertOrUpdate(ingresso);

            if (response == null)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = _ingressoRepository.Delete(id);

            if (response == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var response = _ingressoRepository.GetById(id);

            if (response == null)
                return new BadRequestResult();

            return new OkObjectResult(response);
        }

        public async Task<ActionResult> GetByEventoAsync(int id)
        {
            var response = _ingressoRepository.GetByEvento(id);

            if (response == null)
                return new BadRequestResult();

            return new OkObjectResult(response);
        }
    }
}
