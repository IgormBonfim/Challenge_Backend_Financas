using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IResumosRepository
    {
        public ResumoResponse GetResumoMes(int ano, int mes);
    }
}
