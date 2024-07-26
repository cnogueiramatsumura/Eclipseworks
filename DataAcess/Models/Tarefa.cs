namespace DataAcess.Models
{
    public class Tarefa
    {
        public Tarefa()
        {
            dtCriacao = DateTime.Now;
        }

        public int id { get; set; }
        public string? titulo { get; set; }
        public string? descricao { get; set; }
        public DateTime dtCriacao { get; set; }
        public DateTime dtVencimento { get; set; }
        public int projetoId { get; set; }
        public int prioridadeId { get; set; }
        public int statusId { get; set; }
        public int? usuarioId { get; set; }
        public virtual Projeto? projeto { get; set; }
        public virtual PrioridadeTarefa? prioridade { get; set; }
        public virtual StatusTarefa? status { get; set; }
        public virtual Usuario? usuario { get; set; }


        public Tarefa Copy()
        {
            return (Tarefa)this.MemberwiseClone();
        }
    }
}
