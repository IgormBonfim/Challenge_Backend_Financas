using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository repository;
        public UsuariosController(IUsuariosRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public Response Create([FromBody] UsuarioRequest request)
        {
            return repository.Add(request);
        }
    }
}
