using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7f43b3c0-bfb5-49d0-a9e5-3aa9eeb33e94"));

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Users",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Worker",
                table: "Entries");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Role", "UpdatedDate" },
                values: new object[] { new Guid("907374f4-488f-44e4-b40a-e69e2b5376b1"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", "admin", new DateOnly(1, 1, 1) });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ManagerId",
                table: "Entries",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WorkerId",
                table: "Entries",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UsersId",
                table: "ProjectUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_ManagerId",
                table: "Entries",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_ProjectId",
                table: "Entries",
                column: "ProjectId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_WorkerId",
                table: "Entries",
                column: "WorkerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_ManagerId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_ProjectId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_WorkerId",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ManagerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_WorkerId",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("907374f4-488f-44e4-b40a-e69e2b5376b1"));

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Entries");

            migrationBuilder.AddColumn<string[]>(
                name: "Project",
                table: "Users",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Users",
                table: "Projects",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Entries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Entries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Worker",
                table: "Entries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Project", "Role", "UpdatedDate" },
                values: new object[] { new Guid("7f43b3c0-bfb5-49d0-a9e5-3aa9eeb33e94"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }
    }
}
