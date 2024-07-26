using DataAcess.Migrations;
using DataAcess.ModelConfig;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAcess.Context
{
    public class EclipseDBContext : DbContext
    {
        public EclipseDBContext(DbContextOptions<EclipseDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EclipsDB;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<HistoricoTarefa>(new HistoricoTarefaConfig());
            modelBuilder.ApplyConfiguration<PrioridadeTarefa>(new PrioridadeTarefaConfig());
            modelBuilder.ApplyConfiguration<Projeto>(new ProjetoConfig());
            modelBuilder.ApplyConfiguration<StatusTarefa>(new StatusTarefaConfig());
            modelBuilder.ApplyConfiguration<Tarefa>(new TarefaConfig());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfig());

            new SeedDatabase(modelBuilder);
        }

        public DbSet<PrioridadeTarefa> prioridadeTarefa { get; set; }
        public DbSet<Projeto> projeto { get; set; }
        public DbSet<Tarefa> tarefa { get; set; }
        public DbSet<StatusTarefa> statusTarefa { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
    }
}
