using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Projects_ProjectId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ProjectId",
                table: "Address");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b91ca26-90d5-41ad-b774-e44121356c22"));

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("deb80049-0572-4713-bc3f-6cf4a999f421"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", "admin", "", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("deb80049-0572-4713-bc3f-6cf4a999f421"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("4b91ca26-90d5-41ad-b774-e44121356c22"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", "admin", "", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProjectId",
                table: "Address",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Projects_ProjectId",
                table: "Address",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
