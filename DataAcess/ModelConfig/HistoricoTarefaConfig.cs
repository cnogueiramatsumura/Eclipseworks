using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcess.ModelConfig
{
    public class HistoricoTarefaConfig : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {
            builder.HasKey(x => x.id);
        }
    }
}
