using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IReceitasRepository : IFinancasRepository
    {
        public List<Receita> List();
        public List<Receita> ListByDescicao(string descricao);
    }
}
