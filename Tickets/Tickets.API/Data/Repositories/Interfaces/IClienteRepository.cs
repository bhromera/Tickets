using Tickets.Application.Data.Models;

namespace Tickets.Application.Data.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetById(int id);
        int InsertOrUpdate(Cliente cliente);
        int Delete(int id);
    }
}