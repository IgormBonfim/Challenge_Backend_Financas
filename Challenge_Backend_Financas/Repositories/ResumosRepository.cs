using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Repositories.Interfaces;

namespace Challenge_Backend_Financas.Repositories
{
    public class ResumosRepository : IResumosRepository
    {
        private readonly Contexto dbContext;

        public ResumosRepository(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public ResumoResponse GetResumoMes(int ano, int mes)
        {
            var receitas = dbContext.Receitas.Where(r => r.Data.Year.Equals(ano)).Where(r => r.Data.Month.Equals(mes)).ToList();
            double receitasTotal = 0;
            foreach(var r in receitas)
            {
                receitasTotal += r.Valor;
            }

            var despesas = dbContext.Despesas.Where(r => r.Data.Year.Equals(ano)).Where(r => r.Data.Month.Equals(mes)).ToList();
            double despesasTotal = 0;
            foreach(var d in despesas)
            {
                despesasTotal += d.Valor;
            }

            return new ResumoResponse()
            {
                Mensagem = "Retorno de " + mes + "/" + ano,
                ReceitasTotal = receitasTotal,
                DespesasTotal = despesasTotal,
                SaldoFinal = receitasTotal - despesasTotal
            };
        }
    }
}
