using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop8.Migrations
{
    public partial class oszinten_szolva_nemtudom_ez_minek_kell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c694146-ced2-407c-8dab-336e5552ca79");

            migrationBuilder.DeleteData(
                table: "FolderEvents",
                keyColumn: "Id",
                keyValue: "143ba4ac-c17f-4127-9fb5-f27b2f12e588");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FolderPath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f6a455b-e36d-42fd-87b9-7ca81f1e2b54", 0, "ae8f0983-1395-4e50-878d-f048a66fd1aa", "admin@admin.com", false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEO+8g1Di9BXg2PQcHe9v/s/V9uERyMEIEB9TohhF2ObObt8WhK147UifZf47CA1qSA==", null, false, "018e8980-e824-4418-9d82-febf0eab738e", false, "admin" });

            migrationBuilder.InsertData(
                table: "FolderEvents",
                columns: new[] { "Id", "EventDate", "EventType", "FolderPath" },
                values: new object[] { "c35d11d9-c80b-4284-a4a3-144197545a22", new DateTime(2022, 10, 30, 17, 43, 8, 804, DateTimeKind.Local).AddTicks(9774), "User created the folder.", "C://" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f6a455b-e36d-42fd-87b9-7ca81f1e2b54");

            migrationBuilder.DeleteData(
                table: "FolderEvents",
                keyColumn: "Id",
                keyValue: "c35d11d9-c80b-4284-a4a3-144197545a22");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FolderPath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c694146-ced2-407c-8dab-336e5552ca79", 0, "57740c55-cf7c-42a4-a0f9-519ca57630f7", "admin@admin.com", false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEA2EvFNb3xp3m1uhT1rVGq5IViOuTQpIJ6remf9tQt/NtNqExHaQzCZY01+ahdtg/Q==", null, false, "7f9ff01d-d363-43d3-98b0-c92a65d8d184", false, "admin" });

            migrationBuilder.InsertData(
                table: "FolderEvents",
                columns: new[] { "Id", "EventDate", "EventType", "FolderPath" },
                values: new object[] { "143ba4ac-c17f-4127-9fb5-f27b2f12e588", new DateTime(2022, 10, 28, 0, 34, 34, 289, DateTimeKind.Local).AddTicks(3767), "User opened the folder.", "C://" });
        }
    }
}
