using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PerfilController : Controller
    {
        private readonly IUsuarioPerfil _perfilRepository;
        public PerfilController(IUsuarioPerfil perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [HttpGet]
        public List<UsuarioPerfil> ListPerfis()
        {
            return _perfilRepository.GetAll();
        }
    }
}
