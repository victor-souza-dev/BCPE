﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExtractCssValuesToJson.Migrations
{
    [DbContext(typeof(SQLiteDbContext))]
    [Migration("20240704001812_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ExtractCssValuesToJson.Models.LogRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConfigRequest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentResponse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("FilesLengthRequest")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HttpResponse")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IpClient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LogRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
