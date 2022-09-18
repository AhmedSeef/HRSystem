﻿// <auto-generated />
using System;
using HRSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRSystem.Data.Migrations
{
    [DbContext(typeof(HRSystemContext))]
    partial class HRSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRSystem.Model.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Employee_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Employee_BithDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Employee_EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Employee_type")
                        .HasColumnType("tinyint");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Employee_ID");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HRSystem.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSignIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSignOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoginUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoginUserId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("HRSystem.Model.Employee", b =>
                {
                    b.HasOne("HRSystem.Model.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("HRSystem.Model.Transaction", b =>
                {
                    b.HasOne("HRSystem.Model.Employee", "Employee")
                        .WithMany("Transactions")
                        .HasForeignKey("LoginUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
