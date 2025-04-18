﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoGPCampeonato.Data;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    [DbContext(typeof(MotoGPDbContext))]
    [Migration("20250418211805_AddGranPremioToCarrera")]
    partial class AddGranPremioToCarrera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MotoGPCampeonato.Models.Carrera", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarreraId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GranPremioId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("CarreraId");

                    b.HasIndex("GranPremioId");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Circuito", b =>
                {
                    b.Property<int>("CircuitoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CircuitoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("CircuitoId");

                    b.HasIndex("PaisId");

                    b.ToTable("Circuitos");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Equipo", b =>
                {
                    b.Property<int>("EquipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipoId"));

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("EquipoId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.GranPremio", b =>
                {
                    b.Property<int>("GranPremioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GranPremioId"));

                    b.Property<int>("CircuitoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("GranPremioId");

                    b.HasIndex("CircuitoId");

                    b.HasIndex("PaisId");

                    b.ToTable("GrandesPremios");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaisId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Piloto", b =>
                {
                    b.Property<int>("PilotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PilotoId"));

                    b.Property<int>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("PilotoId");

                    b.HasIndex("EquipoId");

                    b.ToTable("Pilotos");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.ResultadoCarrera", b =>
                {
                    b.Property<int>("ResultadoCarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultadoCarreraId"));

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<int>("PilotoId")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.HasKey("ResultadoCarreraId");

                    b.HasIndex("CarreraId");

                    b.HasIndex("PilotoId");

                    b.ToTable("ResultadosCarrera");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Carrera", b =>
                {
                    b.HasOne("MotoGPCampeonato.Models.GranPremio", "GranPremio")
                        .WithMany()
                        .HasForeignKey("GranPremioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GranPremio");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Circuito", b =>
                {
                    b.HasOne("MotoGPCampeonato.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.GranPremio", b =>
                {
                    b.HasOne("MotoGPCampeonato.Models.Circuito", "Circuito")
                        .WithMany()
                        .HasForeignKey("CircuitoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoGPCampeonato.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Circuito");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Piloto", b =>
                {
                    b.HasOne("MotoGPCampeonato.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.ResultadoCarrera", b =>
                {
                    b.HasOne("MotoGPCampeonato.Models.Carrera", "Carrera")
                        .WithMany("Resultados")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoGPCampeonato.Models.Piloto", "Piloto")
                        .WithMany()
                        .HasForeignKey("PilotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("Piloto");
                });

            modelBuilder.Entity("MotoGPCampeonato.Models.Carrera", b =>
                {
                    b.Navigation("Resultados");
                });
#pragma warning restore 612, 618
        }
    }
}
