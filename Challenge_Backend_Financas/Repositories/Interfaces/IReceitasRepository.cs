using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IReceitasRepository : IFinancasRepository
    {
        public List<FinancaResponse> List();
        public List<Receita> ListByDescicao(string descricao);
        public List<Receita> ListByMes(int ano, int mes);
    }
}
