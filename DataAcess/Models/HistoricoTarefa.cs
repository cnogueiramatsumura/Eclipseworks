namespace DataAcess.Models
{
    public class HistoricoTarefa
    {
        public HistoricoTarefa()
        {
            dtAtualizacao = DateTime.Now;
        }
        public int id { get; set; }
        public string? statusAnterior { get; set; }
        public string? statusAtual { get; set; }
        public string? comentario { get; set; }
        public int usuarioId { get; set; }
        public DateTime dtAtualizacao { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
