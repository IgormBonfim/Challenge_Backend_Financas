using Challenge_Backend_Financas.Entities.Categorias;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasRepository repository;

        public CategoriasController(ICategoriasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Categoria> GetAll()
        {
            return repository.List();
        }

        [HttpGet("{id}")]
        public CategoriasResponse GetById([FromRoute] int id)
        {
            return repository.GetById(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CategoriasRequest request)
        {
            if (repository.Update(id, request))
            {
                return Ok(request);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (repository.Delete(id))
            {
                return Ok("Excluido");
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoriasRequest request)
        {
            if (repository.Add(request))
            {
                return Ok(request);
            }
            return BadRequest();
        }

    }
}
