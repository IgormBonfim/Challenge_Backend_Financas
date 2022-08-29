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
                if (RetornaReceitaExiste(request) != null)
                {
                    return new Response() { 
                        Mensagem = "Essa receita já foi cadastrada esse mês",
                        Type = "warning"
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
                    Mensagem = "Receita adicionada com sucesso",
                    Type = "success"
                };
            }
            catch
            {
                return new Response() 
                { 
                    Mensagem = "Erro ao cadastrar receita",
                    Type = "danger"
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
                return new Response() 
                { 
                    Mensagem = "Receita de id: " + id + " removida com sucesso",
                    Type = "success"
                };
            }
            catch
            {
                return new Response() 
                { 
                    Mensagem = "Ocorreu um erro ao remover receita",
                    Type = "danger"
                };
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
                Data = receitaDb.Data.ToShortDateString(),
                Categoria = categoriaDb
            };
            return receitaReturn;
        }

        public List<FinancasResponse> List()
        {
            var receitas = dbContext.Receitas.Include(r => r.Categoria).ToList();

            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach (var receita in receitas)
            {
                var texto = receita.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                var financa = new FinancasResponse()
                {
                    Id = receita.Id,
                    Descricao = descricaoMaiusculo,
                    Valor = receita.Valor,
                    Data = receita.Data.ToShortDateString(),
                    Categoria = receita.Categoria
                };
                response.Add(financa);
            }
            return response;
        }

        public List<FinancasResponse> ListByDescicao(string descricao)
        {
            var financas = dbContext.Receitas
                .Where(r => EF.Functions.Like(r.Descricao, "%"+descricao+"%"))
                .Include(r => r.Categoria)
                .ToList();

            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach(var financa in financas)
            {
                var texto = financa.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                FinancasResponse financaResponse = new FinancasResponse()
                {
                    Id = financa.Id,
                    Descricao = descricaoMaiusculo,
                    Valor = financa.Valor,
                    Data = financa.Data.ToShortDateString(),
                    Categoria = financa.Categoria,
                };
                response.Add(financaResponse);
            }
            return response;
        }

        public List<FinancasResponse> ListByMes(int ano, int mes)
        {
            var financas = dbContext.Receitas
                .Where(r => r.Data.Year.Equals(ano))
                .Where(r => r.Data.Month.Equals(mes))
                .Include(r => r.Categoria)
                .ToList();

            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach (var financa in financas)
            {
                var texto = financa.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                FinancasResponse financaResponse = new FinancasResponse()
                {
                    Id = financa.Id,
                    Descricao = descricaoMaiusculo,
                    Valor = financa.Valor,
                    Data = financa.Data.ToShortDateString(),
                    Categoria = financa.Categoria,
                };
                response.Add(financaResponse);
            }
            return response;
        }

        public Response Update(int id, FinancasRequest request)
        {
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                var receitaQuery = RetornaReceitaExiste(request);
                var receitaDb = dbContext.Receitas.Find(id);

                if (receitaQuery != null && receitaQuery.Id != id)
                {
                    return new Response() 
                    { 
                        Mensagem = "Não foi possível atualizar a receita, pois a receita está duplicada",
                        Type = "warning"
                    };
                }
                receitaDb.Descricao = request.Descricao;
                receitaDb.Valor = request.Valor;
                receitaDb.IdCategoria = request.IdCategoria;
                dbContext.Update(receitaDb);
                dbContext.SaveChanges();
                return new Response() 
                { 
                    Mensagem = "Receita atualizada com sucesso",
                    Type = "success"
                };
            }
            catch
            {
                return new Response() 
                { 
                    Mensagem = "Ocorreu um erro ao atualizar receita",
                    Type = "danger"
                };
            }
        }

        public Receita RetornaReceitaExiste(FinancasRequest request)
        {
            return dbContext.Receitas
                    .Where(r => r.Descricao.Equals(request.Descricao))
                    .Where(r => r.Data.Year.Equals(request.Data.Year))
                    .Where(r => r.Data.Month.Equals(request.Data.Month))
                    .FirstOrDefault();
        }
    }
}
