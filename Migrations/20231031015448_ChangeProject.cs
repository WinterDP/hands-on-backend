using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Address_AddressId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AddressId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88a56d69-1f10-4bf8-ad03-a6814877e461"));

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

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("1cb729a6-f3da-48ec-aec4-7909c43a4665"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", "admin", "", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1cb729a6-f3da-48ec-aec4-7909c43a4665"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RelationshipUserEntryProject",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RelationshipUserEntryProject",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RelationshipProjectUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RelationshipProjectUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("88a56d69-1f10-4bf8-ad03-a6814877e461"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", "admin", "", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AddressId",
                table: "Projects",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Address_AddressId",
                table: "Projects",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
