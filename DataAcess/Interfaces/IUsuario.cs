using DataAcess.Models;

namespace DataAcess.Interfaces
{
    public interface IUsuario : IRepositoryBase<Usuario>
    {
        bool verificaCPFCadastrado(string cpf);
    }
}
