﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_1001_Fall_2022_Code_Along_Inheritence.Data;

#nullable disable

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("71754de9-3064-4ba7-93be-344345d4a6e1"),
                            Description = "",
                            Name = "Test 1",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("ed7d2a3c-5e3e-4cad-bd43-907dc0d6f767"),
                            Description = "",
                            Name = "Test 2",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = new Guid("09f561b4-def2-4cbc-95ac-1a930aabe6b4"),
                            Description = "",
                            Name = "Test 2",
                            Price = 1.00m
                        },
                        new
                        {
                            Id = new Guid("b77cc9b8-e33d-45a2-91c0-eb397c8549ff"),
                            Description = "",
                            Name = "Test 2",
                            Price = 7.00m
                        });
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

                    b.HasData(
                        new
                        {
                            Email = "example@example.com",
                            Address = "Address 1",
                            Name = "Example 1"
                        },
                        new
                        {
                            Email = "example2@example.com",
                            Address = "Address 2",
                            Name = "Example 2"
                        });
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
