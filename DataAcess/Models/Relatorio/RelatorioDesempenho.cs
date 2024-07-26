namespace DataAcess.Models.Relatorio
{
    public class RelatorioDesempenho
    {
        public int usuarioId { get; set; }
        public string? usuarionome { get; set; }
        public int statusId { get; set; }
        public string? status { get; set; }
        public int? qtdTarefas { get; set; }
    }
}
