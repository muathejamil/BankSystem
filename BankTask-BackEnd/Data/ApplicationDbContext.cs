using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTask_BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(): base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map Entity names to DB Table names 
            modelBuilder.Entity<Bank>().ToTable("Bank");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<AccountType>().ToTable("AccountTypes");
            modelBuilder.Entity<Audit>().ToTable("Audits");
            modelBuilder.Entity<CurrencyExchange>().ToTable("CurrencyExchange");
            modelBuilder.Entity<CurrencyType>().ToTable("CurrencyTypes");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");

            modelBuilder.Entity<Customer>()
                        .HasMany(a => a.Accounts)
                        .WithOne()
                        .HasForeignKey(a => a.CustomerId)
                        .OnDelete(DeleteBehavior.NoAction);

            #region Lookup tables

           
            #region AccountModel
            modelBuilder.Entity<AccountType>().HasData(
                Factory.GetAccountTypeInstance(1, "Checking"),
                Factory.GetAccountTypeInstance(2, "Deposit"));
            #endregion

            #region currency type
            modelBuilder.Entity<CurrencyType>().HasData(
                Factory.GetCurrencyTypeInstance(1, "USD"),
                Factory.GetCurrencyTypeInstance(2, "NIS"),
                Factory.GetCurrencyTypeInstance(3, "JOD"));
            #endregion
            #region CurrencyExchange
            modelBuilder.Entity<CurrencyExchange>().HasData(
                Factory.GetCurrencyExchangeInstace(1, 1, 2, 2.28),
                Factory.GetCurrencyExchangeInstace(2, 1, 3, 0.71),
                Factory.GetCurrencyExchangeInstace(3, 2, 1, 0.30),
                Factory.GetCurrencyExchangeInstace(4, 2, 3, 0.21),
                Factory.GetCurrencyExchangeInstace(5, 3, 1, 1.41),
                Factory.GetCurrencyExchangeInstace(6, 3, 2, 4.77),
                Factory.GetCurrencyExchangeInstace(7, 1, 1, 1),
                Factory.GetCurrencyExchangeInstace(8, 2, 2, 1),
                Factory.GetCurrencyExchangeInstace(9, 3, 3, 1));
            #endregion

            #region TransactionTypes
            modelBuilder.Entity<TransactionsType>().HasData(
                Factory.GetTransactionTypeInstance(1, "Withdraw"),
                 Factory.GetTransactionTypeInstance(2, "Deposit"),
                  Factory.GetTransactionTypeInstance(3, "Transfer"));
            #endregion

            #region BankSingeltonInstance
            modelBuilder.Entity<Bank>().HasData(
               Factory.GetBankInstance(1, "BankSystem"));
            #endregion

            #endregion 
            modelBuilder.Entity<Transaction>().HasOne(e => e.ToAccount)
                                              .WithMany()
                                              .HasForeignKey(e => e.ToAccountId);

            modelBuilder.Entity<Transaction>().HasOne(e => e.FromAccount)
                                              .WithMany()
                                              .HasForeignKey(e => e.FromAccountId);



            modelBuilder.Entity<CurrencyExchange>()
                        .HasOne(ct => ct.FromCurrency)
                        .WithMany()
                        .HasForeignKey(f => f.FromCurrencyId);

            modelBuilder.Entity<CurrencyExchange>()
                        .HasOne(ct => ct.ToCurrency)
                        .WithMany()
                        .HasForeignKey(f => f.ToCurrencyId);

            modelBuilder.Entity<CurrencyExchange>()
                        .HasOne(a => a.ToCurrency)
                        .WithMany()
                        .HasForeignKey(a => a.ToCurrencyId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                        .HasOne(a => a.ToAccount)
                        .WithMany()
                        .HasForeignKey(a => a.ToAccountId)
                        .OnDelete(DeleteBehavior.NoAction);

        }
        #endregion
        // Map Entity names to DB 
        #region Properties
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

    }
}
