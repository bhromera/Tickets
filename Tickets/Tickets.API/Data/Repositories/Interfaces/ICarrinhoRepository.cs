using System.Collections.Generic;
using Tickets.Application.Data.Models;

namespace Tickets.Application.Data.Repositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        Carrinho GetById(int id);
        List<Carrinho> GetByClienteId(int id);
        int InsertOrUpdate(Carrinho carrinho);
        int Delete(int id);
    }
}