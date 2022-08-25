using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Entities
{
    public class FinancasResponse : Response
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; }
        public Categoria Categoria { get; set; }
    }
}
