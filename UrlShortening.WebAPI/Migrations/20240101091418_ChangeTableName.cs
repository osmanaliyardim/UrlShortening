using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortening.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncodedUrls");

            migrationBuilder.CreateTable(
                name: "HashedUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecodedUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashedUrls", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashedUrls");

            migrationBuilder.CreateTable(
                name: "EncodedUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecodedCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncodedUrls", x => x.Id);
                });
        }
    }
}
