﻿// <auto-generated />
using System;
using APIStudent.DAO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    [DbContext(typeof(ScolariteDBContext))]
    [Migration("20221102081757_AjoutChamp_IsOneline")]
    partial class AjoutChamp_IsOneline
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIStudent.Model.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormationId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormationId");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("APIStudent.Model.Formateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formateurs");
                });

            modelBuilder.Entity("APIStudent.Model.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("APIStudent.Model.FormationModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FormationId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormationId");

                    b.HasIndex("ModuleId");

                    b.ToTable("FormationModules");
                });

            modelBuilder.Entity("APIStudent.Model.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descriptif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormateurId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsOneline")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormateurId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("APIStudent.Model.Etudiant", b =>
                {
                    b.HasOne("APIStudent.Model.Formation", "Formation")
                        .WithMany()
                        .HasForeignKey("FormationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formation");
                });

            modelBuilder.Entity("APIStudent.Model.FormationModule", b =>
                {
                    b.HasOne("APIStudent.Model.Formation", "formation")
                        .WithMany()
                        .HasForeignKey("FormationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIStudent.Model.Module", "module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("formation");

                    b.Navigation("module");
                });

            modelBuilder.Entity("APIStudent.Model.Module", b =>
                {
                    b.HasOne("APIStudent.Model.Formateur", "Formateur")
                        .WithMany()
                        .HasForeignKey("FormateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formateur");
                });
#pragma warning restore 612, 618
        }
    }
}
