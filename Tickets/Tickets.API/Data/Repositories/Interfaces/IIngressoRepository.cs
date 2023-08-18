using System.Collections.Generic;
using Tickets.Application.Data.Models;

namespace Tickets.Application.Data.Repositories.Interfaces
{
    public interface IIngressoRepository
    {
        Ingresso GetById(int id);
        List<Ingresso> GetByEvento(int id);
        int InsertOrUpdate(Ingresso ingresso);
        bool UpdateEstoque(bool remove, int quantidade, int id);
        int Delete(int id);
    }
}