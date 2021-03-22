﻿// <auto-generated />
using System;
using BibliotekaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotekaAPI.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20210314174531_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotekaAPI.Models.Biblioteka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.HasKey("ID");

                    b.ToTable("Biblioteke");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Knjiga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrStrana")
                        .HasColumnType("int")
                        .HasColumnName("BrStrana");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<int?>("PolicaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PolicaID");

                    b.ToTable("Knjige");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Polica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BibliotekaID")
                        .HasColumnType("int");

                    b.Property<int>("BrKnjiga")
                        .HasColumnType("int")
                        .HasColumnName("BrKnjiga");

                    b.Property<string>("Zanr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Zanr");

                    b.HasKey("ID");

                    b.HasIndex("BibliotekaID");

                    b.ToTable("Police");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Knjiga", b =>
                {
                    b.HasOne("BibliotekaAPI.Models.Polica", "Polica")
                        .WithMany("Knjige")
                        .HasForeignKey("PolicaID");

                    b.Navigation("Polica");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Polica", b =>
                {
                    b.HasOne("BibliotekaAPI.Models.Biblioteka", "Biblioteka")
                        .WithMany("Police")
                        .HasForeignKey("BibliotekaID");

                    b.Navigation("Biblioteka");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Biblioteka", b =>
                {
                    b.Navigation("Police");
                });

            modelBuilder.Entity("BibliotekaAPI.Models.Polica", b =>
                {
                    b.Navigation("Knjige");
                });
#pragma warning restore 612, 618
        }
    }
}
