namespace DataAcess.Models
{
    public class PrioridadeTarefa
    {
        public int id { get; set; }
        public string? nivelPrioridade { get; set; }
        public virtual List<Tarefa>? tarefas { get; set; }
    }
}
