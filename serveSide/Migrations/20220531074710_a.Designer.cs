﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Migrations
{
    [DbContext(typeof(PomeloDB))]
    [Migration("20220531074710_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Rank", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<int>("RankNum")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.ToTable("Rank");
                });
#pragma warning restore 612, 618
        }
    }
}