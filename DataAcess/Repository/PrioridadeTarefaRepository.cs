using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class PrioridadeTarefaRepository : RepositoryBase<PrioridadeTarefa>, IPrioridadeTarefa
    {
        public PrioridadeTarefaRepository(EclipseDBContext db) : base(db)
        {
        }

        public override List<PrioridadeTarefa> GetAll()
        {
            return db.Set<PrioridadeTarefa>().AsNoTracking().Include(x => x.tarefas).ToList();
        }
    }
}
