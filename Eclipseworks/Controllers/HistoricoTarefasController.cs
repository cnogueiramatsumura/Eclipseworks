using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HistoricoTarefasController : Controller
    {
        private readonly IHistoricoTarefa _historicoRepository;
        public HistoricoTarefasController(IHistoricoTarefa historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        [HttpGet]
        public List<HistoricoTarefa> ListHistorico()
        {
            return _historicoRepository.GetAll();
        }

        [HttpGet]
        public List<HistoricoTarefa> ListHistoricoByUser(int userId)
        {
            return _historicoRepository.ListHistoricoByUser(userId);
        }
    }
}
