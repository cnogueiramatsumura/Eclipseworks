using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusTarefa _StatusTarefaRepository;

        public StatusController(IStatusTarefa statusTarefaRepository)
        {
            _StatusTarefaRepository = statusTarefaRepository;
        }


        [HttpGet]
        [Route("/api/[controller]/ListaStatus")]
        public List<StatusTarefa> ListaStatus()
        {
            return _StatusTarefaRepository.GetAll();
        }
    }
}
