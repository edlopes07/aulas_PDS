using Escola.Services;
using Escola.Models;
using Microsoft.AspNetCore.Mvc;
namespace Escola.Api.Controllers

// METHOD protocol://host:port/path?query=params
{
    [Route("api/[controller]")] // api/aluno
    public class AlunoController : ControllerBase
    {
        private AlunoService service;
        public AlunoController(AlunoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var alunos = service.Consultar();
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Aluno aluno)
        {
            var sucesso = service.Criar(aluno, out var erros);
            if (sucesso)
            {
                return Ok(aluno);
            }
            return UnprocessableEntity(erros);
        }
    }
}
