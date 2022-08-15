namespace Challenge_Backend_Financas.Entities
{
    public class FinancasRequest
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdCategoria { get; set; }
    }
}
