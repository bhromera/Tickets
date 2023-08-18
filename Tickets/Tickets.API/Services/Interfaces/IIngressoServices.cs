using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.Application.Data.Models;

namespace Tickets.API.Services.Interfaces
{
    public interface IIngressoServices
    {
        Task<ActionResult> GetAsync(int id);
        Task<ActionResult> GetByEventoAsync(int id);
        Task<ActionResult> CreateAsync(Ingresso ingresso);
        Task<ActionResult> DeleteAsync(int id);
    }
}
