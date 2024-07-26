using AutoMapper;
using DataAcess.Interfaces;
using DataAcess.Models;
using Eclipseworks.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TarefasController : Controller
    {
        private readonly ITarefa _TarefaRepository;
        private readonly IProjeto _projetoRepository;
        private readonly IUsuario _usuarioRepository;
        private readonly IHistoricoTarefa _historicoRepository;
        private readonly IMapper _Mapper;
        public TarefasController(ITarefa TarefaRepository, IProjeto projetoRepository, IUsuario usuarioRepository, IHistoricoTarefa historicoRepository, IMapper mapper)
        {
            _TarefaRepository = TarefaRepository;
            _projetoRepository = projetoRepository;
            _usuarioRepository = usuarioRepository;
            _historicoRepository = historicoRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public List<Tarefa> ListaTarefas()
        {
            return _TarefaRepository.GetAll();
        }

        [HttpPost]
        [Route("/api/[controller]/add")]
        public IActionResult Add(CreateTarefaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var proj = _projetoRepository.GetById(viewModel.projetoId);
                if (proj == null)
                    return BadRequest("Projeto nao cadastrado");

                var qtdTarefas = _projetoRepository.qtdTarefasCriadas(viewModel.projetoId);
                if (qtdTarefas >= 20)
                    return BadRequest("Limite de tarefas alcançado para este projeto");

                var tarefa = _Mapper.Map<Tarefa>(viewModel);
                _TarefaRepository.Add(tarefa);
                return Ok("Tarefa adicionada com sucesso");
            }
            return BadRequest(viewModel);
        }


        [HttpPut]
        [Route("/api/[controller]/UpdateTarefa")]
        public IActionResult Put(UpdateTarefaViewModel viewModel)
        {
            if (viewModel.usuarioId > 0)
            {
                var user = _usuarioRepository.GetById((int)viewModel.usuarioId);
                if (user == null)
                    return BadRequest("Usuario não cadastrado!");
            }
            var tar = _TarefaRepository.GetById(viewModel.tarefaId);
            if (tar == null)
            {
                return BadRequest("Tarafa não cadastrada!");
            }
            var tarAnterior = tar.Copy();
            tar.titulo = viewModel.titulo;
            tar.descricao = viewModel.descricao;
            tar.dtVencimento = viewModel.dtVencimento;
            tar.statusId = viewModel.statusId;
            tar.usuarioId = viewModel.usuarioId;
            _TarefaRepository.Update(tar);

            //obs:este usuarioId deveria ser do usuario logado na aplicação
            //porem como não tem nenhum metodo de authenticação na aplicação passei este para exemplo              
            var historico = new HistoricoTarefa
            {
                statusAnterior = JsonConvert.SerializeObject(tarAnterior),
                statusAtual = JsonConvert.SerializeObject(tar),
                comentario = viewModel.Comentario,
                dtAtualizacao = DateTime.Now,
                usuarioId = viewModel.usuarioId
            };
            _historicoRepository.Add(historico);
            return Ok("Tarefa Atualizada com sucesso");
        }


        [HttpDelete]
        [Route("/api/[controller]/DeleteTarefa")]
        public IActionResult Delete(int tarefaId)
        {
            var tar = _TarefaRepository.GetById(tarefaId);
            if (tar == null)
                return BadRequest("Tarafe não cadastrada!");

            _TarefaRepository.Delete(tarefaId);
            return Ok("Tarefa Deletada com sucesso");
        }
    }
}
