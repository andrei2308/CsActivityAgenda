﻿// <auto-generated />
using System;
using Assignment_1_Agenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment_1_Agenda.Migrations
{
    [DbContext(typeof(ActivitatiContext))]
    partial class ActivitatiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Assignment_1_Agenda.Clase.Domenii", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DenumireDomeniu")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NecesitateResurse")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resursa")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Domenii");
                });

            modelBuilder.Entity("Assignment_1_Agenda.Clase.Proiecte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("coord")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("deadLine")
                        .HasColumnType("TEXT");

                    b.Property<string>("denumire")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Proiecte");
                });

            modelBuilder.Entity("Assignment_1_Agenda.NewFolder1.Activitati", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("denumire")
                        .HasColumnType("TEXT");

                    b.Property<int?>("domeniuID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("necesitaProiect")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("proiectID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("timpFinish")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("timpStart")
                        .HasColumnType("TEXT");

                    b.Property<int>("tipAct")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("domeniuID");

                    b.HasIndex("proiectID");

                    b.ToTable("Activitatis");
                });

            modelBuilder.Entity("Assignment_1_Agenda.NewFolder1.Activitati", b =>
                {
                    b.HasOne("Assignment_1_Agenda.Clase.Domenii", "domeniu")
                        .WithMany()
                        .HasForeignKey("domeniuID");

                    b.HasOne("Assignment_1_Agenda.Clase.Proiecte", "proiect")
                        .WithMany()
                        .HasForeignKey("proiectID");
                });
#pragma warning restore 612, 618
        }
    }
}
