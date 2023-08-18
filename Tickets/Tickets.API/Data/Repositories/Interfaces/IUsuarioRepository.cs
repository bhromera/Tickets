using Tickets.Application.Data.Models;

namespace Tickets.Application.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetByEmail(string email);
    }
}