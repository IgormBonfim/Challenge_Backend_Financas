using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasRepository repository;
        public ReceitasController(IReceitasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Receita> GetAll()
        {
            return this.repository.List();
        }

        [HttpGet("{id}")]
        public FinancasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
        }

        [HttpGet("descricao")]
        public List<Receita> GetByDescricao([FromQuery] string descricao)
        {
            return repository.ListByDescicao(descricao);
        }

        [HttpGet("{ano}/{mes}")]
        public List<Receita> GetByMes([FromRoute] int ano, [FromRoute] int mes)
        {
            return repository.ListByMes(ano, mes);
        }

        [HttpPut("{id}")]
        public Response Put([FromRoute] int id, [FromBody] FinancasRequest request)
        {
            return repository.Update(id, request);
        }

        [HttpDelete("{id}")]
        public Response Delete([FromRoute] int id)
        {
            return repository.Delete(id);
        }

        [HttpPost]
        public Response Create([FromBody] FinancasRequest request)
        {
            return repository.Add(request);
        }
    }
}
