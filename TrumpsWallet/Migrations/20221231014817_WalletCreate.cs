using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrumpsWallet.Migrations
{
    public partial class WalletCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    money = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toAccountID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "IsDeleted", "LastModified", "Name" },
                values: new object[] { 1, "Usuario Administrador", false, new DateTime(2022, 12, 31, 1, 48, 17, 739, DateTimeKind.Utc).AddTicks(9915), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "IsDeleted", "LastModified", "Name" },
                values: new object[] { 2, "Usuario Cliente", false, new DateTime(2022, 12, 31, 1, 48, 17, 739, DateTimeKind.Utc).AddTicks(9917), "Cliente" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastModified", "LastName", "Password", "Point", "RoleId" },
                values: new object[,]
                {
                    { 1, "Franco44305@gmail.com", "Franco", false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(6), "Villarreal", "123456789", 7, 1 },
                    { 2, "Yelfran@gmail.com", "Yelfran", false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(34), "Giuseppe", "Lion222", 5, 2 },
                    { 3, "RodrigoRoman@gmail.com", "Rodrigo", false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(35), "Roman", "LeoMessi2022", 4, 1 },
                    { 4, "ManzanelliLuciano@gmail.com", "Luciano", false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(36), "Manzanelli", "LM1830", 6, 2 },
                    { 5, "DaniDepablos@gmail.com", "Daniel", false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(37), "Depablos", "Mango207", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "IsDeleted", "LastModified", "creationDate", "isBlocked", "money", "userId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(53), new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(56), false, 81000m, 1 },
                    { 2, false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(66), new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(66), true, 30000m, 2 },
                    { 3, false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(67), new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(67), true, 30000m, 3 },
                    { 4, false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(68), new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(68), true, 30000m, 4 },
                    { 5, false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(69), new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(69), false, 15000m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountID", "Amount", "Concept", "Date", "IsDeleted", "LastModified", "Type", "UserID", "toAccountID" },
                values: new object[,]
                {
                    { 1, 1, 2000m, "Transferencia", new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(85), false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(84), "Payment", 1, 10 },
                    { 2, 2, 200m, "Transferencia", new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(88), false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(88), "Payment", 2, 3 },
                    { 3, 1, 150m, "Recarga", new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(90), false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(89), "Topup", 1, 0 },
                    { 4, 3, 2000m, "Transferencia", new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(91), false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(90), "Payment", 3, 1 },
                    { 5, 4, 2000m, "Recarga", new DateTime(2022, 12, 30, 22, 48, 17, 740, DateTimeKind.Local).AddTicks(92), false, new DateTime(2022, 12, 31, 1, 48, 17, 740, DateTimeKind.Utc).AddTicks(92), "Topup", 4, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_userId",
                table: "Account",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
