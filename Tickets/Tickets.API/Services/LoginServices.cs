using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Login;
using Tickets.API.Services;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ActionResult<dynamic>> AuthenticateAsync(PostLoginRequest request)
        {
            var usuario = _usuarioRepository.GetByEmail(request.Email);

            if (usuario == null || request.Senha != usuario.Senha)
                return new BadRequestObjectResult(new { message = "Usuário ou senha inválidos" });

            var token = TokenServices.GenerateToken(usuario, out var dataExpiracao);

            var response = new
            {
                usuario = usuario.Nome,
                token = token,
                dataExpiracao = dataExpiracao
            };

            return new OkObjectResult(response);
        }
    }
}
