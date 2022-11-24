﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_1001_Fall_2022_Code_Along_Inheritence.Data;

#nullable disable

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20221124001543_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductShoppingCart", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShoppingCartsEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductsId", "ShoppingCartsEmail");

                    b.HasIndex("ShoppingCartsEmail");

                    b.ToTable("ProductShoppingCart");
                });

            modelBuilder.Entity("Web_1001_Fall_2022_Code_Along_Inheritence.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Web_1001_Fall_2022_Code_Along_Inheritence.Models.ShoppingCart", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Web_1001_Fall_2022_Code_Along_Inheritence.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductShoppingCart", b =>
                {
                    b.HasOne("Web_1001_Fall_2022_Code_Along_Inheritence.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_1001_Fall_2022_Code_Along_Inheritence.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_1001_Fall_2022_Code_Along_Inheritence.Models.ShoppingCart", b =>
                {
                    b.HasOne("Web_1001_Fall_2022_Code_Along_Inheritence.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}