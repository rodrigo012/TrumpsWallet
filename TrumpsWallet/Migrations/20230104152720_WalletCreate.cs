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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
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
                    money = table.Column<float>(type: "real", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
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
                    userId = table.Column<int>(type: "int", nullable: false),
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
                values: new object[] { 1, "Usuario Administrador", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(763), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "IsDeleted", "LastModified", "Name" },
                values: new object[] { 2, "Usuario Cliente", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(765), "Cliente" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastModified", "LastName", "Password", "Point", "RoleId" },
                values: new object[,]
                {
                    { 1, "Franco44305@gmail.com", "Franco", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(885), "Villarreal", "123456789", 7, 1 },
                    { 2, "Yelfran@gmail.com", "Yelfran", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(887), "Giuseppe", "Lion222", 5, 2 },
                    { 3, "RodrigoRoman@gmail.com", "Rodrigo", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(889), "Roman", "LeoMessi2022", 4, 1 },
                    { 4, "ManzanelliLuciano@gmail.com", "Luciano", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(890), "Manzanelli", "LM1830", 6, 2 },
                    { 5, "DaniDepablos@gmail.com", "Daniel", false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(890), "Depablos", "Mango207", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "IsDeleted", "LastModified", "creationDate", "isBlocked", "money", "userId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(963), new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(967), false, 81000f, 1 },
                    { 2, false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(982), new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(983), true, 30000f, 2 },
                    { 3, false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(984), new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(984), true, 30000f, 3 },
                    { 4, false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(985), new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(985), true, 30000f, 4 },
                    { 5, false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(986), new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(986), false, 15000f, 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountID", "Amount", "Concept", "Date", "IsDeleted", "LastModified", "Type", "toAccountID", "userId" },
                values: new object[,]
                {
                    { 1, 1, 2000m, "Transferencia", new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1006), false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1006), "Payment", 10, 1 },
                    { 2, 2, 200m, "Transferencia", new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1012), false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1011), "Payment", 3, 2 },
                    { 3, 1, 150m, "Recarga", new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1013), false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1013), "Topup", 0, 3 },
                    { 4, 3, 2000m, "Transferencia", new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1015), false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1014), "Payment", 1, 4 },
                    { 5, 4, 2000m, "Recarga", new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1016), false, new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1016), "Topup", 0, 4 }
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
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
