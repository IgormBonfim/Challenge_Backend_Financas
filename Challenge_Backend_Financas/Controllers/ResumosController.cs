using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_Financas.Controllers
{
    [Route("api/resumo")]
    [ApiController]
    public class ResumosController : ControllerBase
    {
        private readonly IResumosRepository repository;

        public ResumosController(IResumosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{ano}/{mes}")]
        public ResumoResponse GetResumoMes([FromRoute] int ano, [FromRoute] int mes)
        {
            return repository.GetResumoMes(ano, mes);
        }
    }
}
