using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcess.ModelConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.id);
            //builder.HasMany(x => x.tarefas).WithOne(b => b.usuario).HasForeignKey(fk => fk.usuarioId);
            builder.HasMany(x => x.historico).WithOne(b => b.Usuario).HasForeignKey(fk => fk.usuarioId);
            builder.HasOne(x => x.perfil).WithMany(b => b.usuarios).HasForeignKey(fk => fk.perfilid);
            // builder.Navigation(e => e.tarefas).AutoInclude();
        }
    }
}
