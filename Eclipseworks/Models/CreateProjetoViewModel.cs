using System.ComponentModel.DataAnnotations;

namespace Eclipseworks.Models
{
    public class CreateProjetoViewModel
    {
        [Required]
        public string? nome { get; set; }
        [Required]
        public string? descricao { get; set; }
    }
}
