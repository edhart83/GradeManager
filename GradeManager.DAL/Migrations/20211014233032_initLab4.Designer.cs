﻿// <auto-generated />
using System;
using GradeManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GradeManager.DAL.Migrations
{
    [DbContext(typeof(GradeManagerDbContext))]
    [Migration("20211014233032_initLab4")]
    partial class initLab4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GradeManager.Core.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("AssignmentGrade")
                        .HasColumnType("double precision");

                    b.Property<string>("AssignmentName")
                        .HasColumnType("text");

                    b.Property<int?>("StudentID")
                        .HasColumnType("integer");

                    b.Property<bool>("isComplete")
                        .HasColumnType("boolean");

                    b.HasKey("AssignmentID");

                    b.HasIndex("StudentID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GradeManager.Core.Classroom", b =>
                {
                    b.Property<int>("ClassroomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("ClassroomID");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("GradeManager.Core.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("assignmentsCompleted")
                        .HasColumnType("boolean");

                    b.Property<double>("highestGrade")
                        .HasColumnType("double precision");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("numberOfAssignments")
                        .HasColumnType("integer");

                    b.Property<int?>("studentsClassClassroomID")
                        .HasColumnType("integer");

                    b.HasKey("StudentID");

                    b.HasIndex("studentsClassClassroomID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradeManager.Core.Assignment", b =>
                {
                    b.HasOne("GradeManager.Core.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradeManager.Core.Student", b =>
                {
                    b.HasOne("GradeManager.Core.Classroom", "studentsClass")
                        .WithMany()
                        .HasForeignKey("studentsClassClassroomID");

                    b.Navigation("studentsClass");
                });
#pragma warning restore 612, 618
        }
    }
}
