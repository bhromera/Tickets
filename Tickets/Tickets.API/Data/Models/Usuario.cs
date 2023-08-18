using System;
using System.Collections.Generic;
using System.Text;

namespace Tickets.Application.Data.Models
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
    } 
}
