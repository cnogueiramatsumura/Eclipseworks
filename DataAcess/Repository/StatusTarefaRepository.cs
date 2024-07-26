using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class StatusTarefaRepository : RepositoryBase<StatusTarefa>, IStatusTarefa
    {
        public StatusTarefaRepository(EclipseDBContext db) : base(db)
        {
        }

        public override List<StatusTarefa> GetAll()
        {
            return db.Set<StatusTarefa>().AsNoTracking().Include(x => x.tarefas).ToList();
        }
    }
}
