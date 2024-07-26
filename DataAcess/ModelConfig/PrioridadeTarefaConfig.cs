using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcess.ModelConfig
{
    public class PrioridadeTarefaConfig : IEntityTypeConfiguration<PrioridadeTarefa>
    {
        public void Configure(EntityTypeBuilder<PrioridadeTarefa> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.tarefas).WithOne(b => b.prioridade).HasForeignKey(fk => fk.prioridadeId);
            //builder.Navigation(e => e.tarefas).AutoInclude();
        }
    }
}
