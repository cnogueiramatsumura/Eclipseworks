using DataAcess.Models;

namespace DataAcess.Interfaces
{
    public interface IHistoricoTarefa : IRepositoryBase<HistoricoTarefa>
    {
        List<HistoricoTarefa> ListHistoricoByUser(int UserId);
    }
}
