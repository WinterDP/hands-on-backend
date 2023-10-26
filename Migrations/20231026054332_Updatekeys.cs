using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class Updatekeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d132aa08-f6c3-4e93-bcff-291f61c42e3f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "ProjectIds", "Role", "UpdatedDate" },
                values: new object[] { new Guid("fd956696-c187-43db-ae0e-a3f24e0ea4e0"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd956696-c187-43db-ae0e-a3f24e0ea4e0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "ProjectIds", "Role", "UpdatedDate" },
                values: new object[] { new Guid("d132aa08-f6c3-4e93-bcff-291f61c42e3f"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }
    }
}
