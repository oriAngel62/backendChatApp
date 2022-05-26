﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(PomeloDB))]
    [Migration("20220526064912_Init3")]
    partial class Init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Sent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserName");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany("ContactsList")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.HasOne("Domain.Contact", null)
                        .WithMany("MessageList")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Navigation("MessageList");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("ContactsList");
                });
#pragma warning restore 612, 618
        }
    }
}
