using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankTask_BackEnd.Migrations
{
    public partial class _48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: false),
                    TransactionDetials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrencyId = table.Column<int>(nullable: false),
                    ToCurrencyId = table.Column<int>(nullable: false),
                    ExchangeRate = table.Column<double>(nullable: false),
                    CurrencyTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CurrencyExchange_CurrencyTypes_CurrencyTypeID",
                        column: x => x.CurrencyTypeID,
                        principalTable: "CurrencyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyExchange_CurrencyTypes_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyExchange_CurrencyTypes_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MainCurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_CurrencyTypes_MainCurrencyId",
                        column: x => x.MainCurrencyId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(nullable: false),
                    AccountBudget = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    BalanceWithAccountCurrency = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    BalanceWithCustomerMainCurrency = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    CurrencyTypeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ToAccountId = table.Column<int>(nullable: false),
                    FromAccountId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    AccountID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionsType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionsType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { 1, "Checking" },
                    { 2, "Deposit" }
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "BankSystem" });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { 1, "USD" },
                    { 2, "NIS" },
                    { 3, "JOD" }
                });

            migrationBuilder.InsertData(
                table: "TransactionsType",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { 1, "Withdraw" },
                    { 2, "Deposit" },
                    { 3, "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "ID", "CurrencyTypeID", "ExchangeRate", "FromCurrencyId", "ToCurrencyId" },
                values: new object[,]
                {
                    { 7, null, 1.0, 1, 1 },
                    { 1, null, 2.2799999999999998, 1, 2 },
                    { 3, null, 0.29999999999999999, 2, 1 },
                    { 8, null, 1.0, 2, 2 },
                    { 2, null, 0.70999999999999996, 1, 3 },
                    { 4, null, 0.20999999999999999, 2, 3 },
                    { 5, null, 1.4099999999999999, 3, 1 },
                    { 6, null, 4.7699999999999996, 3, 2 },
                    { 9, null, 1.0, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankId",
                table: "Accounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyTypeId",
                table: "Accounts",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchange_CurrencyTypeID",
                table: "CurrencyExchange",
                column: "CurrencyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchange_FromCurrencyId",
                table: "CurrencyExchange",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchange_ToCurrencyId",
                table: "CurrencyExchange",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MainCurrencyId",
                table: "Customers",
                column: "MainCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "CurrencyExchange");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionsType");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");
        }
    }
}
