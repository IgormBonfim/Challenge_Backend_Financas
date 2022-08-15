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
            return this.repository.List();
        }

        [HttpGet("{id}")]
        public FinancasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] FinancasRequest request)
        {
            if (this.repository.Update(id, request))
            {
                return Ok(request);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (this.repository.Delete(id))
            {
                return Ok("Excluido");
            }
            return BadRequest();
        }

        [HttpPost]
        public Response Create([FromBody] FinancasRequest request)
        {
            return repository.Add(request);
        }
    }
}
