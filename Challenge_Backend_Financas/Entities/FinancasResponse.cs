using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Entities
{
    public class FinancasResponse : Response
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }
    }
}
