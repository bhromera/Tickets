using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.API.Contracts.v1.Carrinho
{
    public class PostCarrinhoRequest
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public List<Itens> Itens { get; set; }
    }

    public class Itens
    {
        public int IdIngresso { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
