using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.API.Contracts.v1.Login
{
    public class PostLoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
