using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrumpsWallet.Migrations
{
    public partial class TransacctionsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_User_userId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

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
                        name: "FK_Transactions_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1469), new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1486), new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "creationDate", "isBlocked", "money" },
                values: new object[] { new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1487), new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1488), true, 30000f });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "IsDeleted", "LastModified", "creationDate", "isBlocked", "money", "userId" },
                values: new object[,]
                {
                    { 4, false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1488), new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1489), true, 30000f, 4 },
                    { 5, false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1489), new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1490), false, 15000f, 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountID", "Amount", "Concept", "Date", "IsDeleted", "LastModified", "Type", "UserID", "toAccountID" },
                values: new object[,]
                {
                    { 1, 1, 2000m, "Transferencia", new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1599), false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1598), "Payment", 1, 2 },
                    { 2, 2, 200m, "Transferencia", new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1603), false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1602), "Payment", 2, 5 },
                    { 3, 3, 150m, "Recarga", new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1604), false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1604), "Topup", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountID", "Amount", "Concept", "Date", "IsDeleted", "LastModified", "Type", "UserID", "toAccountID" },
                values: new object[] { 4, 4, 2000m, "Transferencia", new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1606), false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1605), "Payment", 4, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountID", "Amount", "Concept", "Date", "IsDeleted", "LastModified", "Type", "UserID", "toAccountID" },
                values: new object[] { 5, 5, 2000m, "Recarga", new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1607), false, new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1606), "Topup", 5, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_userId",
                table: "Accounts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_userId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 34, 30, 596, DateTimeKind.Utc).AddTicks(1166), new DateTime(2022, 12, 28, 22, 34, 30, 596, DateTimeKind.Local).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 34, 30, 596, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 12, 28, 22, 34, 30, 596, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "creationDate", "isBlocked", "money" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 34, 30, 596, DateTimeKind.Utc).AddTicks(1182), new DateTime(2022, 12, 28, 22, 34, 30, 596, DateTimeKind.Local).AddTicks(1182), false, 1500f });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_User_userId",
                table: "Accounts",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
