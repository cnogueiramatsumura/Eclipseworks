namespace DataAcess.Models
{
    public class Projeto
    {
        public Projeto()
        {
            dtCriacao = DateTime.Now;
        }
        public int id { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public DateTime dtCriacao { get; set; }

        public virtual List<Tarefa>? tarefas { get; set; }
    }
}
