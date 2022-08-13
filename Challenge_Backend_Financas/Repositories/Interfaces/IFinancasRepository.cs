using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories
{
    public interface IFinancasRepository
    {
        public FinancasResponse GetById(int id);
        public bool Add(FinancasRequest request);
        public bool Update(int id, FinancasRequest request);
        public bool Delete(int id);
    }
}
