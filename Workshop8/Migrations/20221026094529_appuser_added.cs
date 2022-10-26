using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop8.Migrations
{
    public partial class appuser_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f83c873-8f6a-4d50-8ba9-414ede606839");

            migrationBuilder.AddColumn<string>(
                name: "FolderPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "User");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FolderPath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5fe4c748-7221-4166-aad4-90510bf2192f", 0, "32f7e23b-5290-46d1-97e1-8978207ea16c", "admin@admin.com", false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMuqCGJCVMFT/iRODEmGhkdqbEaZDH0LXyGR+qqtqg180IH1BX/Z44k4dZ+tpZmPcQ==", null, false, "7bbb4329-c828-4187-97c7-5c854d6b41e2", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe4c748-7221-4166-aad4-90510bf2192f");

            migrationBuilder.DropColumn(
                name: "FolderPath",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "user");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5f83c873-8f6a-4d50-8ba9-414ede606839", 0, "f26d0183-471f-4825-8675-8091160aaeac", "admin@admin.com", false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIVbqNHZ//f9rmnZnlnCMQj5scVf40vc5/L6z8hS4leMzAFD+ZNiqQ0k5STqu5RlYA==", null, false, "fd19d566-5cd9-4917-9ac1-27818e120b88", false, "admin" });
        }
    }
}
