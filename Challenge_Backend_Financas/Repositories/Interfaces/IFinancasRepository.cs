using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories
{
    public interface IFinancasRepository
    {
        public FinancasResponse GetById(int id);
        public Response Add(FinancasRequest request);
        public Response Update(int id, FinancasRequest request);
        public Response Delete(int id);
    }
}
