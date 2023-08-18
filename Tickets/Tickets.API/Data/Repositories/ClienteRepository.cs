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
    public class ClienteRepository : IClienteRepository
    {
        private readonly TicketsContext _db;
        public ClienteRepository(TicketsContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Cliente.Remove(_db.Cliente.FirstOrDefault(t => t.Id == id));
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                return _db.Cliente.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdate(Cliente cliente)
        {
            try
            {
                if (cliente.Id > 0)
                    _db.Entry(cliente).State = EntityState.Modified;
                else
                    _db.Entry(cliente).State = EntityState.Added;

                _db.SaveChanges();

                return cliente.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
