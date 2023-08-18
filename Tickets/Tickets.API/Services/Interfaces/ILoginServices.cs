using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Login;
using Tickets.Application.Data.Models;

namespace Tickets.API.Services.Interfaces
{
    public interface ILoginServices
    {
        Task<ActionResult<dynamic>> AuthenticateAsync(PostLoginRequest request);
    }
}
