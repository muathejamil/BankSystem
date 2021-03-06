﻿// <auto-generated />
using System;
using BankTask_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankTask_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankTask_BackEnd.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountBudget")
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("BalanceWithAccountCurrency")
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("BalanceWithCustomerMainCurrency")
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("BankId");

                    b.HasIndex("CurrencyTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Type = "Checking"
                        },
                        new
                        {
                            ID = 2,
                            Type = "Deposit"
                        });
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Audit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TransactionDetials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Bank", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "BankSystem"
                        });
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.CurrencyExchange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrencyTypeID")
                        .HasColumnType("int");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<int>("FromCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("ToCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyTypeID");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.ToTable("CurrencyExchange");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ExchangeRate = 2.2799999999999998,
                            FromCurrencyId = 1,
                            ToCurrencyId = 2
                        },
                        new
                        {
                            ID = 2,
                            ExchangeRate = 0.70999999999999996,
                            FromCurrencyId = 1,
                            ToCurrencyId = 3
                        },
                        new
                        {
                            ID = 3,
                            ExchangeRate = 0.29999999999999999,
                            FromCurrencyId = 2,
                            ToCurrencyId = 1
                        },
                        new
                        {
                            ID = 4,
                            ExchangeRate = 0.20999999999999999,
                            FromCurrencyId = 2,
                            ToCurrencyId = 3
                        },
                        new
                        {
                            ID = 5,
                            ExchangeRate = 1.4099999999999999,
                            FromCurrencyId = 3,
                            ToCurrencyId = 1
                        },
                        new
                        {
                            ID = 6,
                            ExchangeRate = 4.7699999999999996,
                            FromCurrencyId = 3,
                            ToCurrencyId = 2
                        },
                        new
                        {
                            ID = 7,
                            ExchangeRate = 1.0,
                            FromCurrencyId = 1,
                            ToCurrencyId = 1
                        },
                        new
                        {
                            ID = 8,
                            ExchangeRate = 1.0,
                            FromCurrencyId = 2,
                            ToCurrencyId = 2
                        },
                        new
                        {
                            ID = 9,
                            ExchangeRate = 1.0,
                            FromCurrencyId = 3,
                            ToCurrencyId = 3
                        });
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.CurrencyType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Type = "USD"
                        },
                        new
                        {
                            ID = 2,
                            Type = "NIS"
                        },
                        new
                        {
                            ID = 3,
                            Type = "JOD"
                        });
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MainCurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MainCurrencyId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(15,4)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("int");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.TransactionsType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TransactionsType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Type = "Withdraw"
                        },
                        new
                        {
                            ID = 2,
                            Type = "Deposit"
                        },
                        new
                        {
                            ID = 3,
                            Type = "Transfer"
                        });
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Account", b =>
                {
                    b.HasOne("BankTask_BackEnd.Models.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.CurrencyType", "CurrencyType")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.Customer", null)
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.CurrencyExchange", b =>
                {
                    b.HasOne("BankTask_BackEnd.Models.CurrencyType", null)
                        .WithMany("CurrencyExchanges")
                        .HasForeignKey("CurrencyTypeID");

                    b.HasOne("BankTask_BackEnd.Models.CurrencyType", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.CurrencyType", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Customer", b =>
                {
                    b.HasOne("BankTask_BackEnd.Models.CurrencyType", "MainCurrency")
                        .WithMany("Customers")
                        .HasForeignKey("MainCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankTask_BackEnd.Models.Transaction", b =>
                {
                    b.HasOne("BankTask_BackEnd.Models.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountID");

                    b.HasOne("BankTask_BackEnd.Models.Account", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BankTask_BackEnd.Models.TransactionsType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
