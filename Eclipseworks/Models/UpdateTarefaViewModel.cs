using System.ComponentModel.DataAnnotations;

namespace Eclipseworks.Models
{
    public class UpdateTarefaViewModel
    {
        [Required]
        public int tarefaId { get; set; }
        [Required]
        public string? titulo { get; set; }
        [Required]
        public string? descricao { get; set; }
        public DateTime dtVencimento { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "Status Inválido!")]
        public int statusId { get; set; }
        public int usuarioId { get; set; }
        public string? Comentario { get; set; }
    }
}
