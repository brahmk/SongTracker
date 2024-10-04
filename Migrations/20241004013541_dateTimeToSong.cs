using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongTracker.Migrations
{
    /// <inheritdoc />
    public partial class dateTimeToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Songs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Songs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Songs");
        }
    }
}
