using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IFinancasRepository
    {
        public List<FinancasResponse> List();
        public List<FinancasResponse> ListByDescicao(string descricao);
        public List<FinancasResponse> ListByMes(int ano, int mes);
        public FinancasResponse GetById(int id);
        public Response Add(FinancasRequest request);
        public Response Update(int id, FinancasRequest request);
        public Response Delete(int id);
    }
}
