using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Backend_Financas.Repositories
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
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                var receitaDb = new Receita()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    Data = request.Data.Date
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
            var categoriaDb = dbContext.Categorias.Find(receitaDb.IdCategoria);
            var receitaReturn = new FinancasResponse()
            {
                Descricao = receitaDb.Descricao,
                Valor = receitaDb.Valor,
                Data = receitaDb.Data,
                Categoria = categoriaDb
            };
            return receitaReturn;
        }

        public List<Receita> List()
        {
            return dbContext.Receitas.Include(r => r.Categoria).ToList();
        }

        public List<Receita> ListByDescicao(string descricao)
        {
            return dbContext.Receitas.Where(r => r.Descricao.Equals(descricao)).Include(r => r.Categoria).ToList();
        }

        public bool Update(int id, FinancasRequest request)
        {
            try
            {
                var receitaDb = dbContext.Receitas.Find(id);
                receitaDb.Descricao = request.Descricao;
                receitaDb.Valor = request.Valor;
                dbContext.Update(receitaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
