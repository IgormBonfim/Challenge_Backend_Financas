using Challenge_Backend_Financas.Entities.Categorias;

namespace Challenge_Backend_Financas.Entities
{
    public class ResumoResponse : Response
    {
        public decimal ReceitasTotal { get; set; }
        public decimal DespesasTotal { get; set; }
        public decimal SaldoFinal { get; set; }
        public List<GastoCategoriasResponse> GastoPorCategorias { get; set; }
    }
}
