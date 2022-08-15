using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/despesas")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasRepository repository;
        public DespesasController(IDespesasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Despesa> GetAll()
        {
            return repository.List();
        }

        [HttpGet("{id}")]
        public FinancasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
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
