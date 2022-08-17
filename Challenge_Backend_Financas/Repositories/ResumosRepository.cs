using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Repositories.Interfaces;

namespace Challenge_Backend_Financas.Repositories
{
    public class ResumosRepository : IResumosRepository
    {
        private readonly Contexto dbContext;
        private readonly IReceitasRepository receitasRepository;
        private readonly IDespesasRepository despesasRepository;

        public ResumosRepository(Contexto dbContext, IReceitasRepository receitasRepository, IDespesasRepository despesasRepository)
        {
            this.dbContext = dbContext;
            this.receitasRepository = receitasRepository;
            this.despesasRepository = despesasRepository;
        }

        public ResumoResponse GetResumoMes(int ano, int mes)
        {
            var receitas = receitasRepository.ListByMes(ano, mes);
            double receitasTotal = 0;
            foreach(var r in receitas)
            {
                receitasTotal += r.Valor;
            }

            var despesas = despesasRepository.ListByMes(ano, mes);
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
