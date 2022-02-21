using Microsoft.EntityFrameworkCore;
using SorteioCopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteioCopa.Data
{
    public class CopaContex : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data source = 201.62.57.93;  
                                    Database = BD040684; 
                                    User ID = RA040684;  
                                    Password = 040684";
            optionsBuilder.UseSqlServer(conn);
        }

        public DbSet<paises> Paises { get; set; }
        public DbSet<confederacao> Confederacao { get; set; }
        public DbSet<cagar> Cagar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cagar>()
              .ToTable("cagar")
              .HasKey("Id");
              
   
            modelBuilder.Entity<cagar>()
                .Property(f => f.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();


            modelBuilder.Entity<cagar>()
                .Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .IsRequired();
            
            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<confederacao>()
                .ToTable("Confederacao")
                .HasKey("IdConfederacao");

            modelBuilder.Entity<confederacao>()
                .Property(f => f.IdConfederacao)
                .HasColumnName("ID")
                .HasColumnType("tinyint")
                .IsRequired();

            modelBuilder.Entity<confederacao>()
                .Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<confederacao>()
                .Property(f => f.Sigla)
                .HasColumnName("SIGLA")
                .HasColumnType("varchar(10)")
                .IsRequired();


            ///////////////////////////////////////////////

            modelBuilder.Entity<paises>()
               .ToTable("Paises")
               .HasKey("ID");


            modelBuilder.Entity<paises>()
                .Property(f => f.ID)
                .HasColumnName("ID")
                .HasColumnType("tinyint")
                .IsRequired();

            modelBuilder.Entity<paises>()
                .Property(f => f.Participantes)
                .HasColumnName("PARTICIPANTES")
                .HasColumnType("varchar(50)")
                .IsRequired();


            modelBuilder.Entity<paises>()
                .Property(f => f.RankingFifa)
                .HasColumnName("RANKINGFIFA")
                .HasColumnType("SMALLINT")
                .IsRequired();

            modelBuilder.Entity<paises>()
                .Property(f => f.Sede)
                .HasColumnName("SEDE")
                .HasColumnType("BIT")
                .IsRequired();

            modelBuilder.Entity<paises>()
               .Property(f => f.IdConfederacao)
               .HasColumnName("IDCONFEDERACAO")
               .HasColumnType("TINYINT")
               .IsRequired();

            modelBuilder.Entity<paises>()
                               .HasOne(f => f.confederacao)
                               .WithMany()
                               .HasForeignKey(f => f.IdConfederacao);

            base.OnModelCreating(modelBuilder);
        }




    }
}
