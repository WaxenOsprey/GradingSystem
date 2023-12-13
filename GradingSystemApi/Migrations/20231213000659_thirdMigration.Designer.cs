﻿// <auto-generated />
using GradingSystem.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GradingSystemApi.Migrations
{
    [DbContext(typeof(GradingSystemContext))]
    [Migration("20231213000659_thirdMigration")]
    partial class thirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("GradingSystem.models.Cohort", b =>
                {
                    b.Property<int>("cohortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("cohortId");

                    b.ToTable("Cohorts");
                });

            modelBuilder.Entity("GradingSystem.models.Grade", b =>
                {
                    b.Property<int>("gradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("letterGrade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("numberGrade")
                        .HasColumnType("INTEGER");

                    b.HasKey("gradeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("GradingSystem.models.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CohortId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("studentId");

                    b.HasIndex("CohortId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradingSystem.models.Grade", b =>
                {
                    b.HasOne("GradingSystem.models.Student", "Student")
                        .WithMany("grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradingSystem.models.Student", b =>
                {
                    b.HasOne("GradingSystem.models.Cohort", "Cohort")
                        .WithMany("students")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cohort");
                });

            modelBuilder.Entity("GradingSystem.models.Cohort", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("GradingSystem.models.Student", b =>
                {
                    b.Navigation("grades");
                });
#pragma warning restore 612, 618
        }
    }
}
