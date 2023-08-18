using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Carrinho;
using Tickets.Application.Data.Models;

namespace Tickets.API.Services.Interfaces
{
    public interface ICarrinhoServices
    {
        Task<ActionResult> GetAsync(int id);
        Task<ActionResult> GetByClienteAsync(int id);
        Task<ActionResult> CreateAsync(PostCarrinhoRequest request);
        Task<ActionResult> DeleteAsync(int id);
    }
}
