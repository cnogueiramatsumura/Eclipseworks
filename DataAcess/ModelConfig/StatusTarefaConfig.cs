using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcess.ModelConfig
{
    public class StatusTarefaConfig : IEntityTypeConfiguration<StatusTarefa>
    {
        public void Configure(EntityTypeBuilder<StatusTarefa> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.tarefas).WithOne(b => b.status).HasForeignKey(fk => fk.statusId);
            //builder.Navigation(e => e.tarefas).AutoInclude();
        }
    }
}
