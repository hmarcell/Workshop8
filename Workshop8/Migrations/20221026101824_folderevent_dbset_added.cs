using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop8.Migrations
{
    public partial class folderevent_dbset_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe4c748-7221-4166-aad4-90510bf2192f");

            migrationBuilder.CreateTable(
                name: "FolderEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FolderPath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67018b8b-02c1-4e60-b48f-f0ed4c730a03", 0, "32c31fc7-764d-4b56-a3c7-b3b4cac8246c", "admin@admin.com", false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEPDcu5fWMxU1VYcNMP1g8Cdp+o+lspYuMeVGEJ5QlcBrLpPKG1znrpuUlOVJ1Azfqg==", null, false, "6c3d9a4b-6f88-4cad-99a5-55c6cccb76fb", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolderEvents");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67018b8b-02c1-4e60-b48f-f0ed4c730a03");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FolderPath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5fe4c748-7221-4166-aad4-90510bf2192f", 0, "32f7e23b-5290-46d1-97e1-8978207ea16c", "admin@admin.com", false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMuqCGJCVMFT/iRODEmGhkdqbEaZDH0LXyGR+qqtqg180IH1BX/Z44k4dZ+tpZmPcQ==", null, false, "7bbb4329-c828-4187-97c7-5c854d6b41e2", false, "admin" });
        }
    }
}
