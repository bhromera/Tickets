using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Login;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;

namespace Tickets.API.Controllers.v1
{
    [Route("/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] PostLoginRequest request)
        {
            return await _loginServices.AuthenticateAsync(request);
        }
    }


}
