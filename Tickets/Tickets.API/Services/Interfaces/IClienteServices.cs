using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.Application.Data.Models;

namespace Tickets.API.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<ActionResult> GetAsync(int id);
        Task<ActionResult> CreateAsync(Cliente cliente);
        Task<ActionResult> DeleteAsync(int id);
    }
}
