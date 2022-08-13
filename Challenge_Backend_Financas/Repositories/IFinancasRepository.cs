using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories
{
    public interface IFinancasRepository
    {
        public FinancasResponse GetById(int id);

        public List<FinancasResponse> List();
        public bool Add(FinancasRequest request);
        public bool Update(FinancasRequest request);
        public bool Delete(int id);
    }
}
