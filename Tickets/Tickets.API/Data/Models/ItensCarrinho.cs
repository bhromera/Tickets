namespace Tickets.Application.Data.Models
{
    public class ItensCarrinho
    {
        public int IdCarrinho { get; set; }
        //public Carrinho Carrinho { get; set; }
        public int IdIngresso { get; set; }
        //public Ingresso Ingresso { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
