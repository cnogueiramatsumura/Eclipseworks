using DataAcess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RelatorioController : Controller
    {
        private readonly IProjeto _projetoRepository;
        private readonly IUsuario _usuarioRepository;
        public RelatorioController(IProjeto projetoRepository, IUsuario usuarioRepository)
        {
            _projetoRepository = projetoRepository;
            _usuarioRepository = usuarioRepository;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/api/[controller]/RelatorioDesempenho/{usuarioId}/{projetoId}")]
        public IActionResult RelatorioDesempenho(int usuarioId, int projetoId)
        {
            var user = _usuarioRepository.GetById(usuarioId);
            if (user == null)
                return BadRequest("Usuario não encontrado");
            else if (user.perfilid != 2)
                return BadRequest("Função permitida apenas a gerentes");

            var projeto = _projetoRepository.GetById(projetoId);
            if (projeto == null)
                return BadRequest("Projeto não encontrado");

            var relatorio = _projetoRepository.RelatorioDesempenho(projetoId);
            return CreatedAtAction(nameof(RelatorioDesempenho), null, relatorio);
        }
    }
}
