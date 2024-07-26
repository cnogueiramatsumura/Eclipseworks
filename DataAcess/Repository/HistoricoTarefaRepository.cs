using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class HistoricoTarefaRepository : RepositoryBase<HistoricoTarefa>, IHistoricoTarefa
    {
        public HistoricoTarefaRepository(EclipseDBContext db) : base(db)
        {
        }

        public List<HistoricoTarefa> ListHistoricoByUser(int UserId)
        {
            return db.HistoricoTarefas.AsNoTracking().Where(x => x.usuarioId == UserId).ToList();
        }

        public override List<HistoricoTarefa> GetAll()
        {
            return db.Set<HistoricoTarefa>().AsNoTracking().Include(x => x.Usuario).ToList();
        }
    }
}
