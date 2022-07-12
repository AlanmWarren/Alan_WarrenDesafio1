using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220712134901_CustomerMigration")]
    partial class CustomerMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(58)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(58)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<bool>("EmailSms")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<bool>("Whatsapp")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
