using System;
using System.Collections.Generic;
using System.Text;

namespace Tickets.Application.Data.Models
{
    public class Ingresso : Base
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int IdEvento { get; set; }
        public int Estoque { get; set; }
        //public List<ItensCarrinho> ItensCarrinho { get; set; }
    }
}
