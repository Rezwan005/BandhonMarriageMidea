using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BiodataGeneralInfos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BiodataContacts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BiodataGeneralInfos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BiodataContacts");
        }
    }
}
