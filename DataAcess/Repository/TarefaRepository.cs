using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Repository
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefa
    {
        public TarefaRepository(EclipseDBContext db) : base(db)
        {

        }
        public override List<Tarefa> GetAll()
        {
            return db.Set<Tarefa>().AsNoTracking().Include(x => x.status).Include(x => x.projeto).Include(x => x.prioridade).Include(x => x.usuario).ToList();
        }
    }

}
