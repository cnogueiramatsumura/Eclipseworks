using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PrioridadesController : Controller
    {

        private readonly IPrioridadeTarefa _PrioridadeRepository;
        public PrioridadesController(IPrioridadeTarefa PrioridadeTarefaRepository)
        {
            _PrioridadeRepository = PrioridadeTarefaRepository;
        }


        [HttpGet]
        [Route("/api/[controller]/ListaPrioridades")]
        public List<PrioridadeTarefa> ListaPrioridades()
        {
            return _PrioridadeRepository.GetAll();
        }
    }
}
