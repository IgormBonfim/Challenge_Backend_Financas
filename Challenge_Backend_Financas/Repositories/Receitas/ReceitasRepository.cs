using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Challenge_Backend_Financas.Repositories.Interfaces.Receitas;

namespace Challenge_Backend_Financas.Repositories.Receitas
{
    public class ReceitasRepository : IReceitasRepository
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
            try
            {
                var receitaDb = dbContext.Receitas.Find(id);
                dbContext.Receitas.Remove(receitaDb);
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
            var receitaDb = dbContext.Receitas.Find(id);
            var receitaReturn = new FinancasResponse()
            {
                Descricao = receitaDb.Descricao,
                Valor = receitaDb.Valor,
                Data = receitaDb.Data
            };
            return receitaReturn;
        }

        public List<Receita> List()
        {
            return dbContext.Receitas.ToList();
        }

        public bool Update(int id, FinancasRequest request)
        {
            try
            {
                var receitaDb = dbContext.Receitas.Find(id);
                receitaDb.Descricao = request.Descricao;
                receitaDb.Valor = request.Valor;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
