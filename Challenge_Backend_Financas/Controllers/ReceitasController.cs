using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Entities.Receitas;
using Challenge_Backend_Financas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IFinancasRepository repository;
        public ReceitasController(IFinancasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/api/receitas/{id}")]
        public ReceitasResponse GetById([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/api/receitas/{id}")]
        public ReceitasResponse Put([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/api/receitas/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
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
