﻿// <auto-generated />
using System;
using DataAccsessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccsessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230120080545_mig6_OgrenciGiris_Deleted")]
    partial class mig6_OgrenciGiris_Deleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.Admins", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminMail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminŞifre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyisim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("İsim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Products", b =>
                {
                    b.Property<int>("ÜrünID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("ÜrünAdı")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ÜrünBilgisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ÜrünImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ÜrünID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Setler", b =>
                {
                    b.Property<int>("SetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("SetAdi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SetBilgisi")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SetImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinif")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("SetID");

                    b.ToTable("Setlers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Students", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OkulNumarasi")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sinif")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Soyisim")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TCKimlikNumarasi")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("İsim")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Students_Setler", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SetID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "SetID");

                    b.HasIndex("SetID");

                    b.ToTable("Students_Setler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Students_Setler", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Setler", "Setler")
                        .WithMany("students_Setlers")
                        .HasForeignKey("SetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Students", "Students")
                        .WithMany("students_Setlers")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setler");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Setler", b =>
                {
                    b.Navigation("students_Setlers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Students", b =>
                {
                    b.Navigation("students_Setlers");
                });
#pragma warning restore 612, 618
        }
    }
}
