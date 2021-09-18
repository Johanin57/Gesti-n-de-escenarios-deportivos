﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Dominio.Entidades.cancha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Deporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_escenario")
                        .HasColumnType("int");

                    b.Property<string>("Medidas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("N_Espectadores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("escenarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("escenarioId");

                    b.ToTable("tb_canchas");
                });

            modelBuilder.Entity("Dominio.Entidades.encuentro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_cancha")
                        .HasColumnType("int");

                    b.Property<int>("Id_persona")
                        .HasColumnType("int");

                    b.Property<int>("Id_torneo")
                        .HasColumnType("int");

                    b.Property<int?>("canchaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("canchaId");

                    b.ToTable("tb_encuentros");
                });

            modelBuilder.Entity("Dominio.Entidades.equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Deporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("F_creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_equipos");
                });

            modelBuilder.Entity("Dominio.Entidades.equipos_torneos", b =>
                {
                    b.Property<int>("Id_equipo")
                        .HasColumnType("int");

                    b.Property<int>("Id_torneo")
                        .HasColumnType("int");

                    b.Property<int?>("equiposId")
                        .HasColumnType("int");

                    b.Property<int?>("torneosId")
                        .HasColumnType("int");

                    b.HasKey("Id_equipo", "Id_torneo");

                    b.HasIndex("equiposId");

                    b.HasIndex("torneosId");

                    b.ToTable("tb_equipos_torneos");
                });

            modelBuilder.Entity("Dominio.Entidades.escenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_municipio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("municipioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("municipioId");

                    b.ToTable("tb_escenario");
                });

            modelBuilder.Entity("Dominio.Entidades.municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_municipios");
                });

            modelBuilder.Entity("Dominio.Entidades.persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("F_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_encuentro")
                        .HasColumnType("int");

                    b.Property<string>("N_identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_persona")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_personas");
                });

            modelBuilder.Entity("Dominio.Entidades.personas_equipos", b =>
                {
                    b.Property<int>("Id_persona")
                        .HasColumnType("int");

                    b.Property<int>("Id_equipo")
                        .HasColumnType("int");

                    b.Property<int?>("equiposId")
                        .HasColumnType("int");

                    b.Property<int?>("personasId")
                        .HasColumnType("int");

                    b.HasKey("Id_persona", "Id_equipo");

                    b.HasIndex("equiposId");

                    b.HasIndex("personasId");

                    b.ToTable("tb_personas_equipos");
                });

            modelBuilder.Entity("Dominio.Entidades.torneo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("F_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("F_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("N_rondas")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_torneos");
                });

            modelBuilder.Entity("Dominio.Entidades.torneos_encuentros", b =>
                {
                    b.Property<int>("Id_torneo")
                        .HasColumnType("int");

                    b.Property<int>("Id_encuentro")
                        .HasColumnType("int");

                    b.Property<int>("Id_equipo")
                        .HasColumnType("int");

                    b.Property<int>("Id_equipo2")
                        .HasColumnType("int");

                    b.Property<int>("Id_ganador")
                        .HasColumnType("int");

                    b.Property<int?>("encuentrosId")
                        .HasColumnType("int");

                    b.Property<int?>("equipoId")
                        .HasColumnType("int");

                    b.Property<int?>("torneosId")
                        .HasColumnType("int");

                    b.HasKey("Id_torneo", "Id_encuentro");

                    b.HasIndex("encuentrosId");

                    b.HasIndex("equipoId");

                    b.HasIndex("torneosId");

                    b.ToTable("tb_torneos_encuentros");
                });

            modelBuilder.Entity("Dominio.Entidades.cancha", b =>
                {
                    b.HasOne("Dominio.Entidades.escenario", null)
                        .WithMany("canchas")
                        .HasForeignKey("escenarioId");
                });

            modelBuilder.Entity("Dominio.Entidades.encuentro", b =>
                {
                    b.HasOne("Dominio.Entidades.cancha", null)
                        .WithMany("encuentros")
                        .HasForeignKey("canchaId");
                });

            modelBuilder.Entity("Dominio.Entidades.equipos_torneos", b =>
                {
                    b.HasOne("Dominio.Entidades.equipo", "equipos")
                        .WithMany("equipos_torneos")
                        .HasForeignKey("equiposId");

                    b.HasOne("Dominio.Entidades.torneo", "torneos")
                        .WithMany("equipos_torneos")
                        .HasForeignKey("torneosId");

                    b.Navigation("equipos");

                    b.Navigation("torneos");
                });

            modelBuilder.Entity("Dominio.Entidades.escenario", b =>
                {
                    b.HasOne("Dominio.Entidades.municipio", null)
                        .WithMany("escenarios")
                        .HasForeignKey("municipioId");
                });

            modelBuilder.Entity("Dominio.Entidades.personas_equipos", b =>
                {
                    b.HasOne("Dominio.Entidades.equipo", "equipos")
                        .WithMany("personas_equipos")
                        .HasForeignKey("equiposId");

                    b.HasOne("Dominio.Entidades.persona", "personas")
                        .WithMany("personas_equipos")
                        .HasForeignKey("personasId");

                    b.Navigation("equipos");

                    b.Navigation("personas");
                });

            modelBuilder.Entity("Dominio.Entidades.torneos_encuentros", b =>
                {
                    b.HasOne("Dominio.Entidades.encuentro", "encuentros")
                        .WithMany("torneos_encuentros")
                        .HasForeignKey("encuentrosId");

                    b.HasOne("Dominio.Entidades.equipo", null)
                        .WithMany("torneos_encuentros")
                        .HasForeignKey("equipoId");

                    b.HasOne("Dominio.Entidades.torneo", "torneos")
                        .WithMany("torneos_encuentros")
                        .HasForeignKey("torneosId");

                    b.Navigation("encuentros");

                    b.Navigation("torneos");
                });

            modelBuilder.Entity("Dominio.Entidades.cancha", b =>
                {
                    b.Navigation("encuentros");
                });

            modelBuilder.Entity("Dominio.Entidades.encuentro", b =>
                {
                    b.Navigation("torneos_encuentros");
                });

            modelBuilder.Entity("Dominio.Entidades.equipo", b =>
                {
                    b.Navigation("equipos_torneos");

                    b.Navigation("personas_equipos");

                    b.Navigation("torneos_encuentros");
                });

            modelBuilder.Entity("Dominio.Entidades.escenario", b =>
                {
                    b.Navigation("canchas");
                });

            modelBuilder.Entity("Dominio.Entidades.municipio", b =>
                {
                    b.Navigation("escenarios");
                });

            modelBuilder.Entity("Dominio.Entidades.persona", b =>
                {
                    b.Navigation("personas_equipos");
                });

            modelBuilder.Entity("Dominio.Entidades.torneo", b =>
                {
                    b.Navigation("equipos_torneos");

                    b.Navigation("torneos_encuentros");
                });
#pragma warning restore 612, 618
        }
    }
}
