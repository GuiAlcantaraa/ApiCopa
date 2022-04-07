using Microsoft.EntityFrameworkCore;
using SorteioCopa.Models;
using SorteioCopa.Src.Models;
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
        public DbSet<potes> Potes { get; set; }
        public DbSet<PotePais> PotePais { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<GrupoPais> GrupoPais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
  
            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<confederacao>()
                .ToTable("Confederacao")
                .HasKey("IdConfederacao");

            modelBuilder.Entity<confederacao>()
                .Property(f => f.IdConfederacao)
                .HasColumnName("IDCONFEDERACAO")
                .HasColumnType("INT")
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
                .HasColumnType("INT")
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
               .HasColumnName("IdConfederacao")
               .HasColumnType("INT")
               .IsRequired();

            modelBuilder.Entity<paises>()
                               .HasOne(f => f.Confederacao)
                               .WithMany()
                               .HasForeignKey(f => f.IdConfederacao);

            ////////////////////////////////////////////////////
      

            modelBuilder.Entity<potes>()
             .ToTable("Pote")
             .HasKey("Id");


            modelBuilder.Entity<potes>()
                .Property(f => f.Id)
                .HasColumnName("IDPOTE")
                .HasColumnType("INT")
                .IsRequired();

            modelBuilder.Entity<potes>()
                .Property(f => f.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            ////////////////////////////////////////////////////


             modelBuilder.Entity<PotePais>()
                .ToTable("PotePais")
                .HasKey("Id");

             modelBuilder.Entity<PotePais>()
                 .Property(f => f.Id)
                 .HasColumnName("ID")
                 .HasColumnType("INT")
                 .IsRequired();

             modelBuilder.Entity<PotePais>()
                 .Property(f => f.IdPote)
                 .HasColumnName("IDPOTE")
                 .HasColumnType("INT")
                 .IsRequired();


             modelBuilder.Entity<PotePais>()
               .Property(f => f.IdPais)
               .HasColumnName("IDPAIS")
               .HasColumnType("INT")
               .IsRequired();

            modelBuilder.Entity<PotePais>()
                              .HasOne(f => f.paises)
                              .WithMany()
                              .HasForeignKey(f => f.IdPais);

            modelBuilder.Entity<PotePais>()
                              .HasOne(f => f.potes)
                              .WithMany()
                              .HasForeignKey(f => f.IdPote);

            /////////////////////////////////////////////////



            modelBuilder.Entity<Grupos>()
               .ToTable("Grupos")
               .HasKey("IdGrupo");

            modelBuilder.Entity<Grupos>()
             .Property(f => f.IdGrupo)
             .HasColumnName("IDGRUPO")
             .HasColumnType("INT")
             .IsRequired();

            modelBuilder.Entity<Grupos>()
            .Property(f => f.Descricao)
            .HasColumnName("DESCRICAO")
            .HasColumnType("VARCHAR(10)")
            .IsRequired();
            ////////////////////////////////////////////////

            modelBuilder.Entity<GrupoPais>()
          .ToTable("GrupoPais")
          .HasKey("IdGrupoPais");

            modelBuilder.Entity<GrupoPais>()
           .Property(f => f.IdGrupoPais)
           .HasColumnName("IdGrupoPais")
           .HasColumnType("INT")
           .IsRequired();

            modelBuilder.Entity<GrupoPais>()
           .Property(f => f.IdPais)
           .HasColumnName("PARTICIPANTES")
           .HasColumnType("INT")
           .IsRequired();

            modelBuilder.Entity<GrupoPais>()
           .Property(f => f.IdGrupo)
           .HasColumnName("GRUPOS")
           .HasColumnType("INT")
           .IsRequired();


            modelBuilder.Entity<GrupoPais>()
                              .HasOne(f => f.paises)
                              .WithMany()
                              .HasForeignKey(f => f.IdPais);

            modelBuilder.Entity<GrupoPais>()
                              .HasOne(f => f.Grupos)
                              .WithMany()
                              .HasForeignKey(f => f.IdGrupo);

            base.OnModelCreating(modelBuilder);
        }




    }
}
