﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(WeddingContext))]
    [Migration("20180503011230_ChangeGuestList")]
    partial class ChangeGuestList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("WeddingId");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<string>("WedderOne");

                    b.Property<string>("WedderTwo");

                    b.Property<DateTime>("WeddingDate");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
