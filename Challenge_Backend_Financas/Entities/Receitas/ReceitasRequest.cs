namespace Challenge_Backend_Financas.Entities.Receitas
{
    public class FinancasRequest
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateOnly Data { get; set; }
    }
}
