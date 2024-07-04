using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtractCssValuesToJson.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IpClient = table.Column<string>(type: "TEXT", nullable: false),
                    FilesLengthRequest = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigRequest = table.Column<string>(type: "TEXT", nullable: false),
                    HttpResponse = table.Column<int>(type: "INTEGER", nullable: false),
                    ContentResponse = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRequest", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRequest");
        }
    }
}
