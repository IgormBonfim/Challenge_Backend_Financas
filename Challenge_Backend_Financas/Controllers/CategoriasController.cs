using Challenge_Backend_Financas.Entities;
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
        public Response Put([FromRoute] int id, [FromBody] CategoriasRequest request)
        {
            return repository.Update(id, request);
        }

        [HttpDelete("{id}")]
        public Response Delete([FromRoute] int id)
        {
            return repository.Delete(id);
        }

        [HttpPost]
        public Response Create([FromBody] CategoriasRequest request)
        {
            return repository.Add(request);
        }

    }
}
