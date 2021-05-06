﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rosary.Infrastructure.Database;

namespace Rosary.Migrations
{
    [DbContext(typeof(RosaryContext))]
    [Migration("20210505060323_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Rosary.Domain.Intention", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("_id");

                    b.ToTable("Intentions");
                });

            modelBuilder.Entity("Rosary.Domain.Rosary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Intention_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Intention_id");

                    b.ToTable("Rosaries");
                });

            modelBuilder.Entity("Rosary.Domain.Rosary", b =>
                {
                    b.HasOne("Rosary.Domain.Intention", "Intention")
                        .WithMany()
                        .HasForeignKey("Intention_id");

                    b.Navigation("Intention");
                });
#pragma warning restore 612, 618
        }
    }
}
