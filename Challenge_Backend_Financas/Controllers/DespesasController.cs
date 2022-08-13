using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces.Despesas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasRepository repository;
        public DespesasController(IDespesasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/api/despesas")]
        public List<Despesa> GetAll()
        {
            return this.repository.List();
        }

        [HttpGet("/api/despesas/{id}")]
        public FinancasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
        }

        [HttpPut("/api/despesas/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] FinancasRequest request)
        {
            if (this.repository.Update(id, request))
            {
                return Ok(request);
            }
            return BadRequest();
        }

        [HttpDelete("/api/despesas/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (this.repository.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("/api/despesas")]
        public IActionResult Create([FromBody] FinancasRequest request)
        {
            if (this.repository.Add(request))
            {

                return Created("api/despesas", request);
            }
            return BadRequest();
        }
    }
}
