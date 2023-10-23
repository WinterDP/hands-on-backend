using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hands_on_backend.Migrations
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_Users_ProjectId1",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Entry_ProjectId1",
                table: "Entry");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65f221c3-a1b2-42b2-9f19-1eea55dc4e68"));

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Entry");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PhotoPath", "Role" },
                values: new object[] { new Guid("4c79f8ca-92c1-4515-9041-4d18333cbd32"), "admin@admin.com", "admin", "admin", "", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c79f8ca-92c1-4515-9041-4d18333cbd32"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "Entry",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PhotoPath", "Role" },
                values: new object[] { new Guid("65f221c3-a1b2-42b2-9f19-1eea55dc4e68"), "admin@admin.com", "admin", "admin", "", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_ProjectId1",
                table: "Entry",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_Users_ProjectId1",
                table: "Entry",
                column: "ProjectId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
