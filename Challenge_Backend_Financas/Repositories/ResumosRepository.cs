using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Entities.Categorias;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Backend_Financas.Repositories
{
    public class ResumosRepository : IResumosRepository
    {
        private readonly Contexto dbContext;
        private readonly IReceitasRepository receitasRepository;
        private readonly IDespesasRepository despesasRepository;
        private readonly ICategoriasRepository categoriasRepository;

        public ResumosRepository(Contexto dbContext, IReceitasRepository receitasRepository, IDespesasRepository despesasRepository, ICategoriasRepository categoriasRepository)
        {
            this.dbContext = dbContext;
            this.receitasRepository = receitasRepository;
            this.despesasRepository = despesasRepository;
            this.categoriasRepository = categoriasRepository;
        }

        public ResumoResponse GetResumoMes(int ano, int mes)
        {
            
            var receitasTotal = GetReceitasByMes(ano, mes);
            var despesasTotal = GetDespesasByMes(ano, mes);
            var gastoPorCategorias = GetGastosByCategoria(ano, mes);

            return new ResumoResponse()
            {
                Mensagem = "Retorno de " + mes + "/" + ano,
                ReceitasTotal = receitasTotal,
                DespesasTotal = despesasTotal,
                SaldoFinal = receitasTotal - despesasTotal,
                GastoPorCategorias = gastoPorCategorias
                
            };
        }

        public List<GastoCategoriasResponse> GetGastosByCategoria(int ano, int mes)
        {
            var categorias = categoriasRepository.List();
            List<GastoCategoriasResponse> gastoCategoriasResponses = new List<GastoCategoriasResponse>();

            foreach (var categoria in categorias)
            {
                gastoCategoriasResponses.Add(GetGastoPorCategoria(ano, mes, categoria.NomeCategoria));
            }
            return gastoCategoriasResponses;
        }

        public decimal GetDespesasByMes(int ano, int mes)
        {
            var despesas = despesasRepository.ListByMes(ano, mes);
            decimal despesasTotal = 0;
            foreach (var d in despesas)
            {
                despesasTotal += d.Valor;
            }
            return despesasTotal;
        }

        public decimal GetReceitasByMes(int ano, int mes)
        {
            var receitas = receitasRepository.ListByMes(ano, mes);
            decimal receitasTotal = 0;
            foreach (var r in receitas)
            {
                receitasTotal += r.Valor;
            }
            return receitasTotal;
        }

        public GastoCategoriasResponse GetGastoPorCategoria(int ano, int mes, string categoria)
        {
            var despesasCategoria = dbContext.Despesas
                .Include(r => r.Categoria)
                .Where(r => r.Categoria.NomeCategoria == categoria)
                .Where(r => r.Data.Year == ano)
                .Where(r => r.Data.Month == mes)
                .ToList();
            decimal gastoPorCategoria = 0;
            foreach (var r in despesasCategoria)
            {
                gastoPorCategoria += r.Valor;
            }
            return new GastoCategoriasResponse()
            {
                NomeCategoria = categoria,
                GastoTotal = gastoPorCategoria
            };
        }
    }
}
