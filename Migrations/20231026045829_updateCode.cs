using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class updateCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_ManagerId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_OwnerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ManagerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_OwnerId",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("797d1dd7-b20e-483e-9989-7c5061fd483f"));

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Entries");

            migrationBuilder.AddColumn<Guid[]>(
                name: "ProjectIds",
                table: "Users",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<Guid[]>(
                name: "UserIds",
                table: "Projects",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "ProjectIds", "Role", "UpdatedDate" },
                values: new object[] { new Guid("d7408227-d184-4fe3-a8a0-c9f1d91baff8"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7408227-d184-4fe3-a8a0-c9f1d91baff8"));

            migrationBuilder.DropColumn(
                name: "ProjectIds",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("797d1dd7-b20e-483e-9989-7c5061fd483f"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", "admin", new DateOnly(1, 1, 1) });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ManagerId",
                table: "Entries",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_OwnerId",
                table: "Entries",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_ManagerId",
                table: "Entries",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_OwnerId",
                table: "Entries",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
