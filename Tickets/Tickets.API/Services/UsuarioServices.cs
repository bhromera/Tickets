using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ActionResult<Usuario>> GetByEmailAsync(string email)
        {
            var usuario = _usuarioRepository.GetByEmail(email);

            if (usuario == null)
                return new BadRequestResult();

            return new OkObjectResult(usuario);
        }
    }
}
