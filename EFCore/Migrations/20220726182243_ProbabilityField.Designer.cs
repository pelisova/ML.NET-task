﻿// <auto-generated />
using EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220726182243_ProbabilityField")]
    partial class ProbabilityField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Core.Entities.PVSystem", b =>
                {
                    b.Property<int>("PvSystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Connected")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsHealthy")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PerformanceRatio")
                        .HasColumnType("REAL");

                    b.Property<float>("Probability")
                        .HasColumnType("REAL");

                    b.Property<int>("Riso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temp")
                        .HasColumnType("INTEGER");

                    b.HasKey("PvSystemId");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
