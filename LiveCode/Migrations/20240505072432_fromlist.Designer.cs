﻿// <auto-generated />
using System;
using LiveCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiveCode.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240505072432_fromlist")]
    partial class fromlist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiveCode.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FormListId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormListId");

                    b.HasIndex("stateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("LiveCode.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FormListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormListId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("LiveCode.Models.FormList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("formLists");
                });

            modelBuilder.Entity("LiveCode.Models.PowerRangres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PowerRangres");
                });

            modelBuilder.Entity("LiveCode.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FormListId")
                        .HasColumnType("int");

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormListId");

                    b.HasIndex("countryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("LiveCode.Models.City", b =>
                {
                    b.HasOne("LiveCode.Models.FormList", null)
                        .WithMany("City")
                        .HasForeignKey("FormListId");

                    b.HasOne("LiveCode.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("LiveCode.Models.Country", b =>
                {
                    b.HasOne("LiveCode.Models.FormList", null)
                        .WithMany("Country")
                        .HasForeignKey("FormListId");
                });

            modelBuilder.Entity("LiveCode.Models.State", b =>
                {
                    b.HasOne("LiveCode.Models.FormList", null)
                        .WithMany("State")
                        .HasForeignKey("FormListId");

                    b.HasOne("LiveCode.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LiveCode.Models.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("LiveCode.Models.FormList", b =>
                {
                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("LiveCode.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
