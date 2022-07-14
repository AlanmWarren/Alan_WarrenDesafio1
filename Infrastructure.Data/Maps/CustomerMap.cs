﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.EmailConfirmation);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FullName)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.Cellphone)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.Birthdate)
                .IsRequired();

            builder.Property(x => x.EmailSms)
                .IsRequired();

            builder.Property(x => x.Whatsapp)
                .IsRequired();
            
            builder.Property(x => x.Country)
                .HasColumnType("varchar(58)")
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnType("varchar(58)")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(x => x.Adress)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
