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

        [HttpPost("login")]
        public UsuarioResponse FazerLogin(UsuarioRequest request)
        {
            if (repository.ExisteUsuario(request))
            {
                return new UsuarioResponse()
                {
                    Token = "Logou",
                    Mensagem = "Usuario autenticado com sucesso"
                };
            }
            return new UsuarioResponse()
            {
                Mensagem = "Email ou senha incorreta"
            };
        }
    }
}
