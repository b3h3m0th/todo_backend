﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo_Backend.Model;

namespace ToDo_Backend.Migrations
{
    [DbContext(typeof(ToDosContext))]
    [Migration("20220208081657_AddVerfasserTable")]
    partial class AddVerfasserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("ToDo_Backend.Model.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Geburtsdatum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("persons");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Geburtsdatum = new DateTime(1978, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nachname = "Prinz",
                            Vorname = "Herta"
                        },
                        new
                        {
                            ID = 2,
                            Geburtsdatum = new DateTime(1980, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nachname = "Adalbert",
                            Vorname = "Hubert"
                        });
                });

            modelBuilder.Entity("ToDo_Backend.Model.ToDo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Beschreibung")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Erledigt")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("VerfasserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VerfasserID");

                    b.ToTable("todos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Beschreibung = "Alle CRUD-Operatioen umsetzen",
                            Deadline = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Erledigt = false,
                            Titel = "Webservice fertig implementieren",
                            VerfasserID = 1
                        },
                        new
                        {
                            ID = 2,
                            Beschreibung = "Sollte man eh immer machen :)",
                            Deadline = new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Erledigt = false,
                            Titel = "Mathe lernen",
                            VerfasserID = 2
                        });
                });

            modelBuilder.Entity("ToDo_Backend.Model.ToDo", b =>
                {
                    b.HasOne("ToDo_Backend.Model.Person", "Verfasser")
                        .WithMany("ToDos")
                        .HasForeignKey("VerfasserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verfasser");
                });

            modelBuilder.Entity("ToDo_Backend.Model.Person", b =>
                {
                    b.Navigation("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}