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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TicketsContext _db;
        public UsuarioRepository(TicketsContext db)
        {
            _db = db;
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                return _db.Usuario.Where(x => x.Email.ToLower() == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
