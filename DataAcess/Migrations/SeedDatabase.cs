using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Migrations
{
    public class SeedDatabase
    {
        public SeedDatabase(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrioridadeTarefa>().HasData(
                 new PrioridadeTarefa { id = 1, nivelPrioridade = "baixa" },
                 new PrioridadeTarefa { id = 2, nivelPrioridade = "media" },
                 new PrioridadeTarefa { id = 3, nivelPrioridade = "alta" });

            modelBuilder.Entity<StatusTarefa>().HasData(
                new StatusTarefa { id = 1, descricao = "pendente"},
                new StatusTarefa { id = 2, descricao = "em andamento" },
                new StatusTarefa { id = 3, descricao = "concluída" });

            modelBuilder.Entity<UsuarioPerfil>().HasData(
                new UsuarioPerfil { id = 1, descricao = "Analista" },
                new UsuarioPerfil { id = 2, descricao = "Gerente" });
        }
    }
}
