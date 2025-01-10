﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUygulama.Data;

#nullable disable

namespace WebUygulama.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WebUygulama.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("WebUygulama.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("GarantiSuresi")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("GuncellemeTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marka")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResimUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("StokMiktari")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeknikOzellikler")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}
