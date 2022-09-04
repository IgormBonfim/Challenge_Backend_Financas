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

        public Response Add(FinancasRequest request)
        {
            if (request.IdCategoria <= 0)
            {
                request.IdCategoria = 1;
            }
            try
            {
                if(RetornaDespesaExiste(request) != null)
                {
                    return new Response() { Mensagem = "Essa despesa já foi cadastrada esse mês" };
                }
                var despesaDb = new Despesa()
                {
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    IdCategoria = request.IdCategoria,
                    Data = request.Data,
                };
                dbContext.Despesas.Add(despesaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Despesa cadastrada com sucesso"};
            }
            catch
            {
                return new Response() { Mensagem = "Erro ao cadastrar despesa" };
            }
        }

        public Response Delete(int id)
        {
            try
            {
                var despesaDb = dbContext.Despesas.Find(id);
                dbContext.Despesas.Remove(despesaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Despesa de descrição: " + despesaDb.Descricao + " foi removida com sucesso"};
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao remover despesa"};
            }
        }

        public FinancasResponse GetById(int id)
        {
            var despesaDb = dbContext.Despesas.Include(d => d.Categoria).Where(d => d.Id == id).FirstOrDefault();
            var despesaResponse = new FinancasResponse()
            {
                Descricao = despesaDb.Descricao,
                Valor = despesaDb.Valor,
                Data = despesaDb.Data.ToShortDateString(),
                Categoria = despesaDb.Categoria
            };
            return despesaResponse;
        }

        public List<FinancasResponse> List()
        {
            var financas = dbContext.Despesas.Include(d => d.Categoria).ToList();
            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach (var financa in financas)
            {
                var texto = financa.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                FinancasResponse financaResponse = new FinancasResponse()
                {
                    Descricao = descricaoMaiusculo,
                    Valor = financa.Valor,
                    Data = financa.Data.ToShortDateString(),
                    Categoria = financa.Categoria,
                };
                response.Add(financaResponse);
            }
            return response;
        }

        public List<FinancasResponse> ListByDescicao(string descricao)
        {
            var financas = dbContext.Despesas.Where(d => d.Descricao == descricao).Include(d => d.Categoria).ToList();

            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach (var financa in financas)
            {
                var texto = financa.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                FinancasResponse financaResponse = new FinancasResponse()
                {
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
            var financas = dbContext.Despesas.Where(d => d.Data.Year == ano).Where(d => d.Data.Month == mes).Include(d => d.Categoria).ToList();

            List<FinancasResponse> response = new List<FinancasResponse>();

            foreach (var financa in financas)
            {
                var texto = financa.Descricao;
                var descricaoMaiusculo = char.ToUpper(texto[0]) + texto.Substring(1);

                FinancasResponse financaResponse = new FinancasResponse()
                {
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
                var despesaQuery = RetornaDespesaExiste(request);
                var despesaDb = dbContext.Despesas.Find(id);

                if (despesaQuery != null && despesaQuery.Id != id)
                {
                    return new Response() { Mensagem = "Não foi possível atualizar a despesa, pois a despesa está duplicada" };
                }

                despesaDb.Descricao = request.Descricao;
                despesaDb.Valor = request.Valor;
                dbContext.Update(despesaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Despesa atualizada com sucesso"};
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao atualizar a despesa"};
            }
        }

        public Despesa RetornaDespesaExiste(FinancasRequest request)
        {
            var despesaQuery = dbContext.Despesas
                    .Where(r => r.Descricao == request.Descricao)
                    .Where(r => r.Data.Year == request.Data.Year)
                    .Where(r => r.Data.Month == request.Data.Month)
                    .FirstOrDefault();
            return despesaQuery;
        }
    }
}
