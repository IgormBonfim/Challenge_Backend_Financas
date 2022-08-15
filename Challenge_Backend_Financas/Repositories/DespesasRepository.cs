using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Backend_Financas.Repositories
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
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                var despesaDb = new Despesa()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    IdCategoria = request.IdCategoria,
                    Data = request.Data.Date,
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
            var categoriaDb = dbContext.Categorias.Find(despesaDb.IdCategoria);
            var despesaResponse = new FinancasResponse()
            {
                Descricao = despesaDb.Descricao,
                Valor = despesaDb.Valor,
                Data = despesaDb.Data,
                Categoria = new Categoria
                {
                    Id = categoriaDb.Id,
                    NomeCategoria = categoriaDb.NomeCategoria
                }
            };
            return despesaResponse;
        }

        public List<Despesa> List()
        {
            return dbContext.Despesas.Include(d => d.Categoria).ToList();
        }

        public bool Update(int id, FinancasRequest request)
        {
            try
            {
                var despesaDb = dbContext.Despesas.Find(id);
                despesaDb.Descricao = request.Descricao;
                despesaDb.Valor = request.Valor;
                dbContext.Update(despesaDb);
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
