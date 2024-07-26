using AutoMapper;
using DataAcess.Models;
using Eclipseworks.Models;

namespace Eclipseworks.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Tarefa, UpdateTarefaViewModel>().ReverseMap();
            CreateMap<Tarefa, CreateTarefaViewModel>().ReverseMap();
            CreateMap<Projeto, CreateProjetoViewModel>().ReverseMap();
            CreateMap<Usuario, CreateUsuarioViewModel>().ReverseMap();
        }
    }
}
