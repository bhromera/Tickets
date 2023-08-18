using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tickets.API.Data;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Application.Data.Repositories
{
    public class ItensCarrinhoRepository : IItensCarrinhoRepository
    {
        private readonly TicketsContext _db;
        public ItensCarrinhoRepository(TicketsContext db)
        {
            _db = db;
        }

        public int Delete(int idCarrinho, int idIngresso)
        {
            try
            {
                _db.ItensCarrinho.Remove(_db.ItensCarrinho.FirstOrDefault(x => x.IdCarrinho == idCarrinho && x.IdIngresso == idIngresso));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<ItensCarrinho> GetByCarrinho(int id)
        {
            try
            {
                return _db.ItensCarrinho.Where(x => x.IdCarrinho == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    

        public bool InsertOrUpdate(ItensCarrinho item)
        {
            try
            {
                var ingressoRepository = new IngressoRepository(_db);

                var itemCarrinho = _db.ItensCarrinho.Where(x => x.IdCarrinho == item.IdCarrinho && x.IdCarrinho == item.IdIngresso).FirstOrDefault();

                if (itemCarrinho != null)
                {
                    int quantidade = itemCarrinho.Quantidade - item.Quantidade;

                    ingressoRepository.UpdateEstoque(quantidade < 0, quantidade, item.IdIngresso);

                    _db.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    _db.Entry(item).State = EntityState.Added;
                    ingressoRepository.UpdateEstoque(true, item.Quantidade, item.IdIngresso);
                }

                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertOrUpdate(List<ItensCarrinho> itens)
        {
            try
            {
                foreach (var item in itens)
                {
                    this.InsertOrUpdate(item);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
