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
    [Migration("20210507064955_entities")]
    partial class entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Rosary.Domain.Intention", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("OwnerId")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Intentions");
                });

            modelBuilder.Entity("Rosary.Domain.Rosary", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("IntentionId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("IntentionId");

                    b.ToTable("Rosaries");
                });

            modelBuilder.Entity("Rosary.Domain.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Rosary.Domain.Intention", b =>
                {
                    b.HasOne("Rosary.Domain.User", "Owner")
                        .WithMany("Intentions")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Rosary.Domain.Rosary", b =>
                {
                    b.HasOne("Rosary.Domain.Intention", "Intention")
                        .WithMany()
                        .HasForeignKey("IntentionId");

                    b.Navigation("Intention");
                });

            modelBuilder.Entity("Rosary.Domain.User", b =>
                {
                    b.Navigation("Intentions");
                });
#pragma warning restore 612, 618
        }
    }
}
