using AutoMapper;
using DataAcess.Interfaces;
using DataAcess.Models;
using Eclipseworks.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjetosController : Controller
    {
        private readonly IProjeto _projetoRepository;
        private readonly IMapper _Mapper;
        public ProjetosController(IProjeto projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public List<Projeto> ListaProjetos()
        {
            return _projetoRepository.GetAll();
        }

        [HttpPost]
        [Route("/api/[controller]/add")]
        public IActionResult Add(CreateProjetoViewModel viewModel)
        {
            var proj = _Mapper.Map<Projeto>(viewModel);
            _projetoRepository.Add(proj);
            return Ok("Projeto criado");
        }

        [HttpDelete]
        [Route("/api/[controller]/DeleteProjeto")]
        public IActionResult Delete(int projetoId)
        {
            var qtdTarefas = _projetoRepository.qtdTarefasCriadas(projetoId);
            if (qtdTarefas > 0)
                return BadRequest("Projeto com tarefas pendentes, Exclusa as tarefas primeiro!");

            var proj = _projetoRepository.GetById(projetoId);
            if (proj == null)
                return BadRequest("Projeto nao cadastrado");

            _projetoRepository.Delete(projetoId);
            return Ok("Projeto excluido com sucesso");
        }

    }
}
