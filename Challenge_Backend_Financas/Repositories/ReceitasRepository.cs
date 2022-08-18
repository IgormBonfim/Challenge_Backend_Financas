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

        public Response Add(FinancasRequest request)
        {
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                var receitaQuery = dbContext.Receitas
                    .Where(r => r.Descricao.Equals(request.Descricao))
                    .Where(r => r.Data.Year.Equals(request.Data.Year))
                    .Where(r => r.Data.Month.Equals(request.Data.Month))
                    .FirstOrDefault();
                if (receitaQuery != null)
                {
                    return new Response()
                    {
                        Mensagem = "Essa receita já foi cadastrada esse mês"
                    };
                }

                var receitaDb = new Receita()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    Data = request.Data,
                    IdCategoria = request.IdCategoria,
                };
                dbContext.Receitas.Add(receitaDb);
                dbContext.SaveChanges();
                return new Response()
                {
                    Mensagem = "Receita adicionada com sucesso"
                };
            }
            catch
            {
                return new Response()
                {
                    Mensagem = "Erro ao cadastrar receita"
                };
            }
        }

        public Response Delete(int id)
        {
            try
            {
                var receitaDb = dbContext.Receitas.Find(id);
                dbContext.Receitas.Remove(receitaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Receita de id: " + id + " removida com sucesso" };
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao remover receita" };
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
            return dbContext.Receitas
                .Where(r => r.Descricao.Equals(descricao))
                .Include(r => r.Categoria)
                .ToList();
        }

        public List<Receita> ListByMes(int ano, int mes)
        {
            return dbContext.Receitas
                .Where(r => r.Data.Year.Equals(ano))
                .Where(r => r.Data.Month.Equals(mes))
                .Include(r => r.Categoria)
                .ToList();
        }

        public Response Update(int id, FinancasRequest request)
        {
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                var receitaQuery = dbContext.Receitas
                    .Where(r => r.Descricao.Equals(request.Descricao))
                    .Where(r => r.Data.Year.Equals(request.Data.Year))
                    .Where(r => r.Data.Month.Equals(request.Data.Month))
                    .FirstOrDefault();
                var receitaDb = dbContext.Receitas.Find(id);

                if (receitaQuery != null && receitaQuery.Id != id)
                {
                    return new Response() { Mensagem = "Não foi possível atualizar a receita, pois a receita está duplicada" };
                }
                receitaDb.Descricao = request.Descricao;
                receitaDb.Valor = request.Valor;
                receitaDb.IdCategoria = request.IdCategoria;
                dbContext.Update(receitaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Receita atualizada com sucesso" };
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao atualizar receita"};
            }
        }
    }
}
