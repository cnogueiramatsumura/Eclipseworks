using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcess.ModelConfig
{
    public class ProjetoConfig : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.tarefas).WithOne(b => b.projeto).HasForeignKey(fk => fk.projetoId);
            //builder.Navigation(e => e.tarefas).AutoInclude();
        }
    }
}
