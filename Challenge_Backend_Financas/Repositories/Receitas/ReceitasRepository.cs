using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Receitas
{
    public class ReceitasRepository : IFinancasRepository
    {
        private readonly Contexto dbContext;

        public ReceitasRepository(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Add(FinancasRequest request)
        {
            try
            {
                var receitaDb = new Receita()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    Data = DateTime.Now
                };
                dbContext.Receitas.Add(receitaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FinancasResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FinancasResponse> List()
        {
            throw new NotImplementedException();
        }

        public bool Update(FinancasRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
