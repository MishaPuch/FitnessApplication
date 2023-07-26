﻿// <auto-generated />
using System;
using FitnessApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    [DbContext(typeof(FitnessAppContext))]
    partial class FitnessAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessApp.Models.Calendar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("day")
                        .HasColumnType("datetime2");

                    b.Property<int>("dietId")
                        .HasColumnType("int");

                    b.Property<int>("exerciseId")
                        .HasColumnType("int");

                    b.Property<int>("times")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("FitnessApp.Models.Diet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("calorificValue")
                        .HasColumnType("int");

                    b.Property<double>("carbonFat")
                        .HasColumnType("float");

                    b.Property<string>("foodIngredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("protein")
                        .HasColumnType("float");

                    b.Property<int>("typeOfMeal")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("FitnessApp.Models.Exercise", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("exerciseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exerciseVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessApp.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("calorificValue")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("restTime")
                        .HasColumnType("int");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}