using DataAcess.Models;
using DataAcess.Models.Relatorio;

namespace DataAcess.Interfaces
{
    public interface IProjeto : IRepositoryBase<Projeto>
    {
        int qtdTarefasCriadas(int projetoId);
        List<RelatorioDesempenho> RelatorioDesempenho(int projetoId);
    }
}
