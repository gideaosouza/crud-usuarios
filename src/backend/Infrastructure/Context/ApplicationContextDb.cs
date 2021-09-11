using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
            modelBuilder.Entity<Escolaridade>(new EscolaridadeMapping().Configure);        
            modelBuilder.Entity<Escolaridade>().HasData(
                new Escolaridade{
                    Id = 1,
                    Descricao = "Ensino Fundamental"
                },
                new Escolaridade{
                    Id = 2,
                    Descricao = "Ensino Médio"
                },
                new Escolaridade{
                    Id = 3,
                    Descricao = "Ensino Superior"
                }
            );


        }
    }
}