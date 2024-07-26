namespace DataAcess.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? cpf { get; set; }
        public int perfilid { get; set; }

        public virtual List<HistoricoTarefa>? historico { get; set; }
        public virtual UsuarioPerfil? perfil { get; set; }
    }
}
