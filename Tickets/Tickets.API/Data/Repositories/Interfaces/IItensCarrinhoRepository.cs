using System.Collections.Generic;
using Tickets.Application.Data.Models;

namespace Tickets.Application.Data.Repositories.Interfaces
{
    public interface IItensCarrinhoRepository
    {
        List<ItensCarrinho> GetByCarrinho(int id);
        bool InsertOrUpdate(ItensCarrinho item);
        bool InsertOrUpdate(List<ItensCarrinho> itens);
        int Delete(int idCarrinho, int idIngresso);
    }
}