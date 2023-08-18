using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Application.Data.Models;

namespace Tickets.API.Contracts.v1.Carrinho
{
    public class GetCarrinhoResponse
    {
        public Carrinho Carrinho { get; set; }
    }

    public class Carrinho
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }

        public List<ItensCarrinho> ItensCarrinho { get; set; }
    }
}
