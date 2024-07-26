using System.ComponentModel.DataAnnotations;

namespace Eclipseworks.Models
{
    public class CreateUsuarioViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? cpf { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Perfil não cadastrado!")]
        public int perfilid { get; set; }
    }
}
