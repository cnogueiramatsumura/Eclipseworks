using AutoMapper;
using DataAcess.Interfaces;
using DataAcess.Models;
using Eclipseworks.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepository;
        private readonly IMapper _Mapper;

        public UsuarioController(IUsuario usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _Mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult add(CreateUsuarioViewModel viewModel)
        {
            var cpfCadastrado = _usuarioRepository.verificaCPFCadastrado(viewModel.cpf);
            if (cpfCadastrado)
                return BadRequest("Usuario já cadastrado!");

            var user = _Mapper.Map<Usuario>(viewModel);
            _usuarioRepository.Add(user);
            return Ok("Usuario Cadastrado com Sucesso!");
        }

    }
}
