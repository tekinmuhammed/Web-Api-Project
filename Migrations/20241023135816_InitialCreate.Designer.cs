﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241023135816_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("AccountStatus")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("CardStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CcvCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExpiryMonth")
                        .HasColumnType("integer");

                    b.Property<int>("ExpiryYear")
                        .HasColumnType("integer");

                    b.HasKey("CardId");

                    b.HasIndex("AccountId");

                    b.ToTable("cards", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RiskLimit")
                        .HasColumnType("numeric");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("CardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CardId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionTypeId"));

                    b.Property<string>("TransactionTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("transactions_types", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebApplication1.Models.Card", b =>
                {
                    b.HasOne("WebApplication1.Models.Account", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebApplication1.Models.Transaction", b =>
                {
                    b.HasOne("WebApplication1.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("WebApplication1.Models.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Card");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebApplication1.Models.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
