using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Entities.Receitas;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Challenge_Backend_Financas.Repositories.Interfaces.Receitas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasRepository repository;
        public ReceitasController(IReceitasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/api/receitas")]
        public List<Receita> GetAll()
        {
            return this.repository.List();
        }

        [HttpGet("/api/receitas/{id}")]
        public FinancasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
        }

        [HttpPut("/api/receitas/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] FinancasRequest request)
        {
            if (this.repository.Update(id, request))
            {
                return Ok(request);
            }
            return BadRequest();
        }

        [HttpDelete("/api/receitas/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (this.repository.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("/api/receitas")]
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
