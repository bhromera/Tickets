using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.Application.Data.Models;

namespace Tickets.API.Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<ActionResult<Usuario>> GetByEmailAsync(string email);
        
    }
}
