using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRestriction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7408227-d184-4fe3-a8a0-c9f1d91baff8"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "ProjectIds", "Role", "UpdatedDate" },
                values: new object[] { new Guid("d132aa08-f6c3-4e93-bcff-291f61c42e3f"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d132aa08-f6c3-4e93-bcff-291f61c42e3f"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "ProjectIds", "Role", "UpdatedDate" },
                values: new object[] { new Guid("d7408227-d184-4fe3-a8a0-c9f1d91baff8"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }
    }
}
