using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    // public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    // {
    //     public ApplicationDbContext CreateDbContext(string[] args)
    //     {
    //         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //         optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=livraria.db;Trusted_Connection=True;");

    //         return new ApplicationDbContext(optionsBuilder.Options);
    //     }
    // }
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
        }
    }
}