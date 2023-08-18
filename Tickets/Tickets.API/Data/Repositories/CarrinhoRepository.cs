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
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly TicketsContext _db;
        public CarrinhoRepository(TicketsContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Carrinho.Remove(_db.Carrinho.FirstOrDefault(t => t.Id == id));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Carrinho GetById(int id)
        {
            try
            {
                return _db.Carrinho.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Carrinho> GetByClienteId(int id)
        {
            try
            {
                return _db.Carrinho.Where(x => x.IdCliente == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdate(Carrinho carrinho)
        {
            try
            {
                if (carrinho.Id > 0)
                    _db.Entry(carrinho).State = EntityState.Modified;
                else
                    _db.Entry(carrinho).State = EntityState.Added;

                _db.SaveChanges();

                return carrinho.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
