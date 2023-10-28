using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipAddDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52fd93f6-98f7-471c-a1ad-d94ffd4b2554"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "RelationshipUserEntryProject",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedDate",
                table: "RelationshipUserEntryProject",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "RelationshipProjectUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedDate",
                table: "RelationshipProjectUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("50ef2fb9-5068-4340-a6e0-5856a54fa98d"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", "admin", new DateOnly(1, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50ef2fb9-5068-4340-a6e0-5856a54fa98d"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RelationshipUserEntryProject");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RelationshipUserEntryProject");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RelationshipProjectUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RelationshipProjectUsers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("52fd93f6-98f7-471c-a1ad-d94ffd4b2554"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", "admin", new DateOnly(1, 1, 1) });
        }
    }
}
