using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Persistencia.AppRepositorio
{
    public class AppContext:DbContext
    {
        public DbSet<persona> tb_personas{get;set;}
        public DbSet<equipo> tb_equipos{get;set;}
        public DbSet<municipio> tb_municipios{get;set;}
        public DbSet<escenario> tb_escenario{get;set;}
        public DbSet<cancha> tb_canchas{get;set;}
        public DbSet<torneo> tb_torneos{get;set;}
        public DbSet<encuentro> tb_encuentros{get;set;}
        public DbSet<equipos_torneos> tb_equipos_torneos{get;set;}
        public DbSet<torneos_encuentros> tb_torneos_personas{get;set;}
        public DbSet<personas_equipos> tb_personas_equipos{get;set;}

        //Metodos 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q0CR927 ; Initial Catalog=DB_Deportistas");
            }
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<personas_equipos>().HasKey(x => new { x.Id_persona, x.Id_equipo });
            ModelBuilder.Entity<equipos_torneos>().HasKey(x => new{x.Id_equipo, x.Id_torneo});
            ModelBuilder.Entity<torneos_encuentros>().HasKey(x=> new { x.Id_torneo, x.Id_encuentro});
        }
    
    }
}