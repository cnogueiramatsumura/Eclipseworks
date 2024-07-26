using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuario
    {
        public UsuarioRepository(EclipseDBContext db) : base(db)
        {
        }

        public override List<Usuario> GetAll()
        {
            return db.Set<Usuario>().AsNoTracking().Include(x => x.perfil).ToList();
        }

        public bool verificaCPFCadastrado(string cpf)
        {
            return db.usuario.FirstOrDefault(x => x.cpf == cpf) != null;
        }
    }
}
