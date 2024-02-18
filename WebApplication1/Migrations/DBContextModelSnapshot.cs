﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.ResultModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageExecutionTime")
                        .HasColumnType("double precision")
                        .HasColumnName("averageExecutionTime");

                    b.Property<double>("AverageIndicatorValue")
                        .HasColumnType("double precision")
                        .HasColumnName("averageIndicatorValue");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("filename");

                    b.Property<decimal>("MaxIndicatorValue")
                        .HasColumnType("numeric")
                        .HasColumnName("maxIndicatorValue");

                    b.Property<double>("MedianIndicatorValue")
                        .HasColumnType("double precision")
                        .HasColumnName("medianIndicatorValue");

                    b.Property<decimal>("MinIndicatorValue")
                        .HasColumnType("numeric")
                        .HasColumnName("minIndicatorValue");

                    b.Property<int>("RowsCount")
                        .HasColumnType("integer")
                        .HasColumnName("rowsCount");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("startTime");

                    b.Property<TimeSpan>("TotalTime")
                        .HasColumnType("interval")
                        .HasColumnName("totalTime");

                    b.Property<int>("ValueId")
                        .HasColumnType("integer")
                        .HasColumnName("valueId");

                    b.HasKey("Id");

                    b.HasIndex("ValueId");

                    b.ToTable("result");
                });

            modelBuilder.Entity("WebApplication1.Models.ValueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateTime");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fileName");

                    b.Property<double>("IndicatorValue")
                        .HasColumnType("double precision")
                        .HasColumnName("indicatorValue");

                    b.Property<int>("TimeInSeconds")
                        .HasColumnType("integer")
                        .HasColumnName("timeInSeconds");

                    b.HasKey("Id");

                    b.ToTable("value");
                });

            modelBuilder.Entity("WebApplication1.Models.ResultModel", b =>
                {
                    b.HasOne("WebApplication1.Models.ValueModel", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Value");
                });
#pragma warning restore 612, 618
        }
    }
}
