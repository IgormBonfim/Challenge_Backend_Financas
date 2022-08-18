using Challenge_Backend_Financas.Entities.Categorias;

namespace Challenge_Backend_Financas.Entities
{
    public class ResumoResponse : Response
    {
        public double ReceitasTotal { get; set; }
        public double DespesasTotal { get; set; }
        public double SaldoFinal { get; set; }
        public List<GastoCategoriasResponse> GastoPorCategorias { get; set; }
    }
}
