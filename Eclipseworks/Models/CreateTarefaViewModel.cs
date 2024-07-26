using System.ComponentModel.DataAnnotations;

namespace Eclipseworks.Models
{
    public class CreateTarefaViewModel
    {
        [Required]
        public string? titulo { get; set; }
        [Required]
        public string? descricao { get; set; }
        [Required]
        public DateTime dtVencimento { get; set; }
        [Required]
        public int projetoId { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "Prioridade Inválida!")]
        public int prioridadeId { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "Status Inválido!")]
        public int statusId { get; set; }
        public int? usuarioId { get; set; }
    }
}
