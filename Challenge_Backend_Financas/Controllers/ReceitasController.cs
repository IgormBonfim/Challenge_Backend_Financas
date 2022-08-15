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
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromBody] FinancasRequest request)
        {
            if (this.repository.Add(request))
            {

                return Created("api/receitas", request);    
            }
            return BadRequest();
        }
    }
}
