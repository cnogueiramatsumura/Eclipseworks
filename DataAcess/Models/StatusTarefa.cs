namespace DataAcess.Models
{
    public class StatusTarefa
    {
        public int id { get; set; }
        public string? descricao { get; set; }

        public virtual List<Tarefa>? tarefas { get; set; }
    }
}
