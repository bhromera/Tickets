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
    public class IngressoRepository : IIngressoRepository
    {
        private readonly TicketsContext _db;
        public IngressoRepository(TicketsContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Ingresso.Remove(_db.Ingresso.FirstOrDefault(t => t.Id == id));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Ingresso> GetByEvento(int id)
        {
            try
            {
                return _db.Ingresso.Where(x => x.IdEvento == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ingresso GetById(int id)
        {
            try
            {
                return _db.Ingresso.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertOrUpdate(Ingresso ingresso)
        {
            try
            {
                if (ingresso.Id > 0)
                    _db.Entry(ingresso).State = EntityState.Modified;
                else
                    _db.Entry(ingresso).State = EntityState.Added;

                _db.SaveChanges();

                return ingresso.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateEstoque(bool remove, int quantidade, int id)
        {
            try
            {
                var ingresso = GetById(id);

                if (ingresso != null)
                {
                    if (remove)
                        ingresso.Estoque -= quantidade;
                    else
                        ingresso.Estoque += quantidade;

                    _db.Entry(ingresso).State = EntityState.Modified;
                    _db.SaveChanges();

                    return true;
                }
                else
                    return false;                
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
