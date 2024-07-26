namespace DataAcess.Models
{
    public class UsuarioPerfil
    {
        public int id { get; set; }
        public string? descricao { get; set; }
        public List<Usuario>? usuarios { get; set; }
    }
}
