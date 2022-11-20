﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCSProject.Database;

namespace PCSProject.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCSProject.Domain.Emp_Qualification", b =>
                {
                    b.Property<int>("EmpQuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Employee_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Marks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Q_Id")
                        .HasColumnType("int");

                    b.HasKey("EmpQuId");

                    b.HasIndex("Employee_Id");

                    b.HasIndex("Q_Id");

                    b.ToTable("Emp_Qualification");
                });

            modelBuilder.Entity("PCSProject.Domain.Employee", b =>
                {
                    b.Property<int>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emp_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Entry_By")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Entry_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Employee_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PCSProject.Domain.QualificationList", b =>
                {
                    b.Property<int>("Q_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Q_Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Q_Id");

                    b.ToTable("QualificationList");
                });

            modelBuilder.Entity("PCSProject.Domain.Emp_Qualification", b =>
                {
                    b.HasOne("PCSProject.Domain.Employee", "Employee")
                        .WithMany("Emp_Qualifications")
                        .HasForeignKey("Employee_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCSProject.Domain.QualificationList", "QualificationList")
                        .WithMany("Emp_Qualifications")
                        .HasForeignKey("Q_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("QualificationList");
                });

            modelBuilder.Entity("PCSProject.Domain.Employee", b =>
                {
                    b.Navigation("Emp_Qualifications");
                });

            modelBuilder.Entity("PCSProject.Domain.QualificationList", b =>
                {
                    b.Navigation("Emp_Qualifications");
                });
#pragma warning restore 612, 618
        }
    }
}
