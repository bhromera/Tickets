using System;

namespace Tickets.Application.Data.Models
{
    public class Carrinho : Base
    {
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        //public List<ItensCarrinho> Itens { get; set; }
    }
}
