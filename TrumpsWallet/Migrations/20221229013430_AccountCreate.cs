using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrumpsWallet.Migrations
{
    public partial class AccountCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 34, 30, 596, DateTimeKind.Utc).AddTicks(1182), new DateTime(2022, 12, 28, 22, 34, 30, 596, DateTimeKind.Local).AddTicks(1182) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 18, 41, 871, DateTimeKind.Utc).AddTicks(6126), new DateTime(2022, 12, 28, 22, 18, 41, 871, DateTimeKind.Local).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 18, 41, 871, DateTimeKind.Utc).AddTicks(6156), new DateTime(2022, 12, 28, 22, 18, 41, 871, DateTimeKind.Local).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "creationDate" },
                values: new object[] { new DateTime(2022, 12, 29, 1, 18, 41, 871, DateTimeKind.Utc).AddTicks(6157), new DateTime(2022, 12, 28, 22, 18, 41, 871, DateTimeKind.Local).AddTicks(6157) });
        }
    }
}
