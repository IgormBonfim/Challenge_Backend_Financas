using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces.Despesas;

namespace Challenge_Backend_Financas.Repositories.Despesas
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly Contexto dbContext;

        public DespesasRepository(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Add(FinancasRequest request)
        {
            try
            {
                var despesaDb = new Despesa()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    Data = DateTime.Now
                };
                dbContext.Despesas.Add(despesaDb);
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
            try
            {
                var despesaDb = dbContext.Despesas.Find(id);
                dbContext.Despesas.Remove(despesaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public FinancasResponse GetById(int id)
        {
            var despesaDb = dbContext.Despesas.Find(id);
            var despesaReturn = new FinancasResponse()
            {
                Descricao = despesaDb.Descricao,
                Valor = despesaDb.Valor,
                Data = despesaDb.Data
            };
            return despesaReturn;
        }

        public List<Despesa> List()
        {
            return dbContext.Despesas.ToList();
        }

        public bool Update(int id, FinancasRequest request)
        {
            try
            {
                var despesaDb = dbContext.Despesas.Find(id);
                despesaDb.Descricao = request.Descricao;
                despesaDb.Valor = request.Valor;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
