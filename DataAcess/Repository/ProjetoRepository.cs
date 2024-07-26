using Azure.Core;
using Azure.Core.Pipeline;
using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using DataAcess.Models.Relatorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

namespace DataAcess.Repository
{
    public class ProjetoRepository : RepositoryBase<Projeto>, IProjeto
    {
        public ProjetoRepository(EclipseDBContext db) : base(db)
        {
        }

        public override List<Projeto> GetAll()
        {
            return db.Set<Projeto>().AsNoTracking().Include(x => x.tarefas).ToList();
        }

        public int qtdTarefasCriadas(int projetoId)
        {
            var proj = db.projeto.Include(x => x.tarefas).FirstOrDefault(x => x.id == projetoId);
            var qtdTarefas = proj?.tarefas?.Count ?? 0;
            return qtdTarefas;
        }

        public List<RelatorioDesempenho> RelatorioDesempenho(int projetoId)
        {
            var query = @$"select u.id 'usuarioId',u.name 'usuarionome',st.id 'statusId',st.descricao 'status',
                           count(t.id) as 'qtdTarefas'                           
                           from projeto p
                           inner join tarefa t on p.id = t.projetoId
                           inner join usuario u on u.id = t.usuarioId
                           inner join StatusTarefa st on t.statusId = st.id
                           where p.id = {projetoId}
                           group by u.id,u.name,st.id,st.descricao";
            var formatablestring = FormattableStringFactory.Create(query);
            var rel = db.Database.SqlQuery<RelatorioDesempenho>(formatablestring).ToList();
            return rel;
        }
    }
}
