﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.Api.Data;

namespace ProAgil.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190406010223_Add ImageURL")]
    partial class AddImageURL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("ProAgil.Api.Model.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataEvento");

                    b.Property<string>("ImagemURL");

                    b.Property<string>("Local");

                    b.Property<string>("Lote");

                    b.Property<int>("QtdPessoas");

                    b.Property<string>("Tema");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
