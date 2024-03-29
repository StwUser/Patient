﻿// <auto-generated />
using System;
using DataBasePatient.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBasePatient.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240203152534_Initer")]
    partial class Initer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataBasePatient.Data.Models.Active", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActiveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Active");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Given", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Givens");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ActiveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActiveId");

                    b.HasIndex("GenderId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Given", b =>
                {
                    b.HasOne("DataBasePatient.Data.Models.Patient", "Patient")
                        .WithMany("Givens")
                        .HasForeignKey("PatientId");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Patient", b =>
                {
                    b.HasOne("DataBasePatient.Data.Models.Active", "Active")
                        .WithMany()
                        .HasForeignKey("ActiveId");

                    b.HasOne("DataBasePatient.Data.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("Active");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("DataBasePatient.Data.Models.Patient", b =>
                {
                    b.Navigation("Givens");
                });
#pragma warning restore 612, 618
        }
    }
}
