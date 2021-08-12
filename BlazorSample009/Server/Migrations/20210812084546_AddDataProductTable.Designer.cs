﻿// <auto-generated />
using BlazorSample009.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorSample009.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210812084546_AddDataProductTable")]
    partial class AddDataProductTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BlazorSample009.Shared.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = "001",
                            Name = "Book",
                            Price = 1000
                        },
                        new
                        {
                            Id = "002",
                            Name = "Pen",
                            Price = 500
                        },
                        new
                        {
                            Id = "003",
                            Name = "Laptop",
                            Price = 30000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
