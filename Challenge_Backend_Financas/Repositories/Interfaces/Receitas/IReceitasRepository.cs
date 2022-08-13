using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces.Receitas
{
    public interface IReceitasRepository : IFinancasRepository
    {
        public List<Receita> List();
    }
}
