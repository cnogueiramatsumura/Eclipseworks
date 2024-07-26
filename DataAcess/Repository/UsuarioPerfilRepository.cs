using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class UsuarioPerfilRepository : RepositoryBase<UsuarioPerfil>, IUsuarioPerfil
    {
        public UsuarioPerfilRepository(EclipseDBContext db) : base(db)
        {
        }

        public override List<UsuarioPerfil> GetAll()
        {
            return db.Set<UsuarioPerfil>().AsNoTracking().Include(x => x.usuarios).ToList();
        }
    }
}
