using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IDespesasRepository : IFinancasRepository
    {
        public List<Despesa> List();
        public List<Despesa> ListByDescicao(string descricao);
        public List<Despesa> ListByMes(int ano, int mes);
    }
}