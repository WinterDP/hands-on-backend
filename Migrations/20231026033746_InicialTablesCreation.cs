using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsLogger.Migrations
{
    /// <inheritdoc />
    public partial class InicialTablesCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Project = table.Column<string>(type: "text", nullable: false),
                    Manager = table.Column<string>(type: "text", nullable: false),
                    Worker = table.Column<string>(type: "text", nullable: false),
                    Files = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Users = table.Column<string[]>(type: "text[]", nullable: true),
                    Entries = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: false),
                    Project = table.Column<string[]>(type: "text[]", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "PhotoPath", "Project", "Role", "UpdatedDate" },
                values: new object[] { new Guid("7f43b3c0-bfb5-49d0-a9e5-3aa9eeb33e94"), new DateOnly(1, 1, 1), "admin@admin.com", "admin", "admin", "", null, "admin", new DateOnly(1, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
